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
    public partial class OperatorNode : Node
    {
        private const char
            OP_LAYOUT_RETURN = '$',
            OP_LAYOUT_INPUT = '#',
            OP_LAYOUT_LABEL = '@';
        private const string
            OP_COMMON_BINARY = "$#@#",
            OP_COMMON_PREUNARY = "$@#",
            OP_COMMON_POSTUNARY = "$#@";

        public struct Operator
        {
            public readonly string Layout;
            public readonly string[] Labels;
            public readonly string FormatString;

            public Operator(string FormatString, string Layout, params string[] Labels)
            {
                this.Layout = Layout;
                this.Labels = Labels;
                this.FormatString = FormatString;
            }

            public int InputCount()
            {
                return Layout.Count(c => c == '#');
            }
        }

        public static readonly Operator[] Operators;

        static OperatorNode()
        {
            Operators = new Operator[] {
                new Operator("{0}.{1}", OP_COMMON_BINARY, "."),
                new Operator("{0} + {1}", OP_COMMON_BINARY, "+"),
                new Operator("{0} - {1}", OP_COMMON_BINARY, "-"),
                new Operator("{0} * {1}", OP_COMMON_BINARY, "*"),
                new Operator("{0} / {1}", OP_COMMON_BINARY, "*"),
                new Operator("{0}++", OP_COMMON_POSTUNARY, "++"),
                new Operator("++{0}", OP_COMMON_PREUNARY, "++")
            };
        }


        Operator mOp;

        public OperatorNode(Operator Op)
            : base()
        {
            InitializeComponent();
            mOp = Op;

            // Create the controls needed (linked buttons, labels, etc)
            CreateOperatorLayout(Op);
        }

        private Control[] CreateOperatorLayout(Operator Op)
        {
            // Start at position 0
            // For $, create an output button
            // For #, create an input button
            // For @, create a label with the corresponding string for its text

            List<Control> ToReturn = new List<Control>();
            mInputs = new LinkedButton[Op.InputCount()];

            int lbl = 0;
            int input = 0;

            for (int i = 0; i < Op.Layout.Length; i++)
            {
                switch (Op.Layout[i])
                {
                    case OP_LAYOUT_RETURN:
                        mOutput = new LinkedButton(this, typeof(object), false);
                        mOutput.Location = new Point(i * 100, 0);
                        mOutput.Text = "OUT";

                        ToReturn.Add(mOutput);
                        break;
                        
                    case OP_LAYOUT_INPUT:
                        mInputs[input] = new LinkedButton(this, typeof(object), true);
                        mInputs[input].Location = new Point(i * 100, 0);
                        mInputs[input].Text = "" + (char)((int)'a' + input);

                        ToReturn.Add(mInputs[input]);
                        input++;
                        break;

                    case OP_LAYOUT_LABEL:
                        Label l = new Label();
                        l.Location = new Point(i * 100, 0);
                        l.Text = Op.Labels[lbl];
                        l.AutoSize = true;
                        l.Parent = this;

                        ToReturn.Add(l);
                        lbl++;
                        break;
                }
            }

            return ToReturn.ToArray();
        }

        public override string GetFormatString()
        {
            return mOp.FormatString;
        }
    }
}
