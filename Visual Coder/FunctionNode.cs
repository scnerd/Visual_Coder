using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

namespace Visual_Coder
{
    internal partial class FunctionNode : Node
    {

        private MethodInfo mMethod;

        public FunctionNode(MethodInfo Method)
            : base()
        {
            mMethod = Method;

            InitializeComponent();
            bool HasReturn = Method.ReturnType != typeof(void);

            if (HasReturn)
            {
                lblMethodName.Location = new Point(lblMethodName.Location.X + 100, lblMethodName.Location.Y);
            }

            if (Method.IsStatic)
                lblMethodName.Text = Method.DeclaringType.Name + "." + Method.Name;
            else
                lblMethodName.Text = Method.Name;

            mInputs = new LinkedButton[Method.GetParameters().Length];
            int CurPos = lblMethodName.Right + 25;

            for (int i = 0; i < Method.GetParameters().Length; i++)
            {
                mInputs[i] = new LinkedButton(this, Method.GetParameters()[i].ParameterType, true);
                mInputs[i].Location = new Point(CurPos, 0);
                mInputs[i].Text = Method.GetParameters()[i].ParameterType.ToString() + " " + Method.GetParameters()[i].Name;

                CurPos += 100;
                this.Controls.Add(mInputs[i]);
            }

            if (HasReturn)
            {
                LinkedButton b = new LinkedButton(this, Method.ReturnType, false);
                b.Location = new Point(lblMethodName.Left - 100, 0);
                b.Text = Method.ReturnType.Name;

                mOutput = b;
                this.Controls.Add(b);
            }
            else
            {
                mOutput = null;
            }
        }

        public override string GetFormatString()
        {
            return (mMethod.IsStatic ? mMethod.DeclaringType.Name + "." : "")
                + mMethod.Name + "(" + string.Join(", ", Enumerable.Range(0, mInputs.Length).Select(i => "{" + i + "}")) + ")";
        }

    }


}
