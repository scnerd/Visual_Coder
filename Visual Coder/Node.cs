using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Visual_Coder
{
    public abstract partial class Node : UserControl
    {
        internal static Action<Node> Delete = null;
        internal static Action<Type> ShowMethods = null;

        protected LinkedButton[] mInputs;
        protected LinkedButton mOutput = null;

        public Node()
        {
            if (Delete == null || ShowMethods == null)
            {
                throw new InvalidOperationException("Node.Delete must be set before any nodes may be created");
            }

            InitializeComponent();
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;

            this.ContextMenu = new ContextMenu(new MenuItem[] {
                new MenuItem("Show Methods", new EventHandler((s, e) => ShowMethods(mOutput.ValueType))),
                new MenuItem("Unlink", new EventHandler((s, e) => UnlinkNode())),
                new MenuItem("Delete", new EventHandler((s, e) => DeleteNode()))
            });

            
        }

        private void UnlinkNode()
        {
            if (mOutput != null)
            {
                foreach (LinkedButton l in mOutput.GetLinks())
                {
                    LinkedButton.Unlink(mOutput, l);
                }
            }
            foreach (LinkedButton l in mInputs)
            {
                if (l.IsLinked())
                {
                    LinkedButton.Unlink(l.GetLinks()[0], l);
                }
            }
        }

        private void DeleteNode()
        {
            UnlinkNode();
            Delete(this);
        }

        public bool IsLinked()
        {
            // Make sure that all input parameters have a value
            foreach (LinkedButton b in mInputs)
                if (!b.IsLinked())
                    return false;
            return true;
        }

        public virtual Node[] OutputConnected()
        {
            if (mOutput != null)
                return mOutput.GetLinks().Select(b => (Node)b.Parent).ToArray();
            else
                return new Node[0];
        }

        public virtual Node[] InputConnected()
        {
            return mInputs.Select(b => b.GetLinks()[0]).Select(b => (Node)b.Parent).ToArray();
        }

        public Type[] TypesUsed()
        {
            return mInputs.Select(button => button.ValueType).Concat(mOutput == null ? new Type[0] : new Type[] { mOutput.ValueType }).ToArray();
        }

        public abstract string GetFormatString();



        public class LinkedButton : Button
        {
            protected static Action<LinkedButton> sLinker;

            public static void SetupLinker(Action<LinkedButton> Linker)
            {
                sLinker = Linker;
            }

            public readonly bool IsInput;
            public readonly Type ValueType;
            private List<LinkedButton> LinkedBtns = new List<LinkedButton>();
            private Line InboundConnection = null;
            private Node Owner;

            public LinkedButton(Node Owner, Type T, bool IsInput)
                : base()
            {
                ValueType = T;
                this.Owner = Owner;
                this.IsInput = IsInput;
                this.Click += (s, e) => sLinker(this);
                this.TextAlign = ContentAlignment.MiddleCenter;
                this.AutoSize = true;
                this.Parent = Owner;
                this.MinimumSize = new Size(50, 20);
            }

            public bool IsLinked()
            { return LinkedBtns.Count > 0; }

            internal LinkedButton[] GetLinks()
            {
                return LinkedBtns.ToArray();
            }

            public static void Link(LinkedButton A, LinkedButton B, Control Parent)
            {
                if (A.Owner == B.Owner)
                    return;

                if ((A.IsInput && A.IsLinked()) || (B.IsInput && B.IsLinked()))
                    throw new InvalidOperationException("Tried to double-link an input value.");

                if (A.IsInput)
                {
                    if(!A.ValueType.IsAssignableFrom(B.ValueType))
                        throw new InvalidOperationException("Tried to link unlike variable types.");
                    Parent.Controls.Add(A.InboundConnection = new LinkLine(B, A, Parent));
                }
                else
                {
                    if (!B.ValueType.IsAssignableFrom(A.ValueType))
                        throw new InvalidOperationException("Tried to link unlike variable types.");
                    Parent.Controls.Add(B.InboundConnection = new LinkLine(A, B, Parent));
                }

                A.LinkedBtns.Add(B);
                B.LinkedBtns.Add(A);
            }

            public static void Unlink(LinkedButton A, LinkedButton B)
            {
                if (A.IsInput)
                    A.InboundConnection.Delete();
                else
                    B.InboundConnection.Delete();

                A.LinkedBtns.Remove(B);
                B.LinkedBtns.Remove(A);
            }
        }

        public abstract class Line : Control
        {
            private Control A, B;
            private Control Parent;

            public Line(Control Start, Control End, Control Parent)
            {
                A = Start;
                B = End;
                this.Parent = Parent;
                Parent.Paint += Refresh;
                Parent.Invalidate();
            }

            public void Refresh(object s, EventArgs e)
            {
                Graphics g = Parent.CreateGraphics();
                Pen p = new Pen(Color.Maroon, 3);
                p.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
                p.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;

                g.DrawLine(p, GetCenter(A), GetCenter(B));

                g.Flush();
                g.Dispose();

                base.Refresh();
            }

            internal void Delete()
            {
                Parent.Paint -= Refresh;
                Parent.Controls.Remove(this);
            }

            private Point GetCenter(Control c)
            {
                return (new Point(c.Parent.Left + c.Left + c.Width / 2, c.Parent.Top + c.Top + c.Height / 2));
            }
        }

        public class LinkLine : Line
        {
            public LinkLine(LinkedButton Start, LinkedButton End, Control Parent)
                : base(Start, End, Parent)
            { }
        }

        public class ControlLine : Line
        {
            public ControlLine(Node Start, Node End, Control Parent)
                : base(Start, End, Parent)
            { }
        }
    }
}
