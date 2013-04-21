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
    public partial class ConstantNode : Node
    {
        internal static readonly string[] ConstTypes = new string[]{
            "string",
            "int",
            "double",
            "char",
            "bool",
            "decimal",
            "float",
            "long",
            "short"};
        internal static readonly Dictionary<string, Type> ConstConverter = new Dictionary<string, Type>();
        private static readonly Dictionary<Type, Func<string, bool>> Checker = new Dictionary<Type, Func<string, bool>>();

        static ConstantNode()
        {
            ConstConverter.Add("string", typeof(string));
            ConstConverter.Add("int", typeof(int));
            ConstConverter.Add("double", typeof(double));
            ConstConverter.Add("char", typeof(char));
            ConstConverter.Add("bool", typeof(bool));
            ConstConverter.Add("decimal", typeof(decimal));
            ConstConverter.Add("float", typeof(float));
            ConstConverter.Add("long", typeof(long));
            ConstConverter.Add("short", typeof(short));

            Checker.Add(typeof(string), (s) => true);
            Checker.Add(typeof(int), (s) => { int i; return int.TryParse(s, out i); });
            Checker.Add(typeof(double), (s) => { double i; return double.TryParse(s, out i); });
            Checker.Add(typeof(char), (s) => s.Length > 0);
            Checker.Add(typeof(bool), (s) => { bool i; return bool.TryParse(s, out i); });
            Checker.Add(typeof(decimal), (s) => { decimal i; return decimal.TryParse(s, out i); });
            Checker.Add(typeof(float), (s) => { float i; return float.TryParse(s, out i); });
            Checker.Add(typeof(long), (s) => { long i; return long.TryParse(s, out i); });
            Checker.Add(typeof(short), (s) => { short i; return short.TryParse(s, out i); });
        }


        private Type mT;

        public ConstantNode(Type T)
            : base()
        {
            InitializeComponent();

            textBox1.TextChanged += new EventHandler(textBox1_TextChanged);
            mInputs = new LinkedButton[0];

            mOutput = new LinkedButton(this, T, false);
            mOutput.Location = new Point(textBox1.Left - 100, 0);
            mOutput.Text = T.Name;

            this.Controls.Add(mOutput);

            mT = T;
        }

        void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (IsValid())
                textBox1.BackColor = Color.White;
            else
                textBox1.BackColor = Color.Red;
            // Need to switch through all possibilities and 
        }

        private bool IsValid()
        {
            return Checker[mT](textBox1.Text);
        }

        public override Node[] OutputConnected()
        {
            if (!IsValid())
            {
                throw new InvalidOperationException("Cannot use this constant " + textBox1.Text + ", it is invalid for type " + mT.Name);
            }

            return base.OutputConnected();
        }

        public override string GetFormatString()
        {
            //Special cases
            if (mT.IsEquivalentTo(typeof(string)))
            {
                return "\"" + textBox1.Text + "\"";
            }
            else if (mT.IsEquivalentTo(typeof(char)))
            {
                return "\'" + textBox1.Text + "\'";
            }
            else
            {
                return textBox1.Text;
            } 
        }
    }
}
