#define USENAMESPACES

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.IO;

namespace Visual_Coder
{
    public partial class Form1 : Form
    {
        protected static readonly Dictionary<string, int> CurrentMode = new Dictionary<string, int>();
        protected const int
            METHODS = 0,
            CONSTANTS = 1,
            OPERATORS = 2;

        private List<AssemblyName> mAssemblies = new List<AssemblyName>();
        private List<string> mNamespaces = new List<string>();
        private List<Type> mAvailableClasses = new List<Type>();
        private MethodInfo[] mAvailableMethods = new MethodInfo[0];

        private Node.LinkedButton mLinkA = null;

        private List<Node> mCommands = new List<Node>();

        static Form1()
        {
            CurrentMode.Add("Methods", METHODS);
            CurrentMode.Add("Constants", CONSTANTS);
            CurrentMode.Add("Operators", OPERATORS);
        }

        public Form1()
        {
            InitializeComponent();

            Node.Delete = (n) => { mCommands.Remove(n); spltMainContainer.Panel2.Controls.Remove(n); };
            Node.ShowMethods = (t) => { DisplayMethodsOfType(t); };

            Node.LinkedButton.SetupLinker(b => HandleLink(b));

            // Get all assemblies, and keep them in a list
            mAssemblies = Assembly.GetExecutingAssembly().GetReferencedAssemblies().ToList();
            mAssemblies.Insert(0, Assembly.GetExecutingAssembly().GetName());
            List<ListViewItem> items = new List<ListViewItem>();

            // Put them on display, allowing user to selected desired assemblies
#if USENAMESPACES
            mNamespaces = new List<string>(
                mAssemblies
                .SelectMany((name) => Assembly.Load(name).GetTypes()
                    .Select(type => type.Namespace)
                    .Distinct())
                .Distinct()
                .Where(str => str != null)
                );
            mNamespaces.Sort();
            foreach(string n in mNamespaces)
            {
                clstAssemblies.Items.Add(n, false);
            }
#else
            foreach (AssemblyName a in mAssemblies)
            {
                clstAssemblies.Items.Add(a.Name, false);
            }
#endif

            cmbSelectionPicker.SelectedIndex = 0;
        }

        private void AssemblySelected(object sender, ItemCheckEventArgs e)
        {
            // When an assembly gets changed, find all classes that belong to it
            Type[] Classes;
#if USENAMESPACES
            Classes = mAssemblies
                .Select(name => Assembly.Load(name))
                .SelectMany(assem => assem.GetTypes())
                .Where(type => type.Namespace == mNamespaces[e.Index])
                .ToArray();
#else
            Classes = Assembly.Load(mAssemblies[e.Index].FullName).GetTypes().ToArray();
#endif

            // If it got unchecked, then remove its classes from the Classes list
            if (e.NewValue != CheckState.Checked)
                foreach (Type t in Classes)
                    mAvailableClasses.Remove(t);
            // Else, put them on the Classes list
            else
                foreach (Type t in Classes)
                    mAvailableClasses.Add(t);

            // Display a sorted list of all available classes
            mAvailableClasses = mAvailableClasses.OrderBy(l => l.Name).ToList();
            lstClasses.Items.Clear();
            lstClasses.Items.AddRange(mAvailableClasses.Select(t => new ListViewItem(t.Name)).ToArray());

            // Clear the display of available methods
            mAvailableMethods = new MethodInfo[0];
            if (cmbSelectionPicker.SelectedIndex == METHODS)
            {
                lstMethods.Clear();
            }
        }

        private void ClassSelected(object sender, EventArgs e)
        {
            // Display all methods belonging to the requested class
            if (lstClasses.SelectedIndices.Count <= 0)
            {
                return;
            }

            DisplayMethodsOfType(mAvailableClasses[lstClasses.SelectedIndices[0]]);
        }

        private void DisplayMethodsOfType(Type T)
        {
            cmbSelectionPicker.SelectedIndex = METHODS;

            lstMethods.Clear();
            mAvailableMethods = T.GetMethods().OrderBy(m => m.Name).ToArray();
            lstMethods.Items.AddRange(mAvailableMethods.Select(m => new ListViewItem(m.Name)).ToArray());
        }

        private void DrawingBoard_Click(object sender, MouseEventArgs e)
        {
            // If a method isn't selected, do nothing
            if (lstMethods.SelectedItems.Count <= 0)
            {
                return;
            }

            // Otherwise, generate a new Node to and add it to our code base
            Node f = null;

            switch (CurrentMode[cmbSelectionPicker.Text])
            {
                case METHODS:
                    f = new FunctionNode(mAvailableMethods[lstMethods.SelectedIndices[0]]);
                    break;

                case CONSTANTS:
                    f = new ConstantNode(ConstantNode.ConstConverter[lstMethods.SelectedItems[0].Text]);
                    break;

                case OPERATORS:
                    f = new OperatorNode(OperatorNode.Operators[lstMethods.SelectedIndices[0]]);
                    break;

                default:
                    throw new InvalidOperationException("You somehow got something besides Meth/Const/Op in the cmb box.");
                    break;
            }

            f.Location = e.Location;
            mCommands.Add(f);
            spltMainContainer.Panel2.Controls.Add(f);
        }

        private void HandleLink(Node.LinkedButton Btn)
        {
            if (mLinkA == null)
            {
                mLinkA = Btn;
            }
            else
            {
                if (mLinkA.IsInput != Btn.IsInput)
                {
                    Node.LinkedButton.Link(mLinkA, Btn, spltMainContainer.Panel2);
                }
                mLinkA = null;
            }
        }

        private void cmbSelectionPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            lstMethods.Items.Clear();
            switch (cmbSelectionPicker.SelectedIndex)
            {
                case METHODS:
                    ClassSelected(sender, e);
                    break;

                case CONSTANTS:
                    lstMethods.Items.AddRange(ConstantNode.ConstTypes.Select(c => new ListViewItem(c)).ToArray());
                    break;

                case OPERATORS:
                    lstMethods.Items.AddRange(OperatorNode.Operators
                        .Select(op => string.Format(op.FormatString, 
                            Enumerable.Range((int)'a', 26)
                            .Select(j => (char)j).Cast<object>().ToArray()
                            ))
                        .Select(s => new ListViewItem(s)).ToArray());
                    break;
            }
        }

        public void SampleFunction1(string s)
        {
            MessageBox.Show(s);
        }

        public static int SampleFunction2()
        {
            return 3;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Type t;
            if ((t = Type.GetType(txtClassSearch.Text, false, true)) != null)
            {
                DisplayMethodsOfType(t);
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saver.Tag = saver.ShowDialog();
            if ((DialogResult)saver.Tag == DialogResult.OK)
            {
                using (TextWriter Write = new StreamWriter(saver.FileName))
                {
                    Write.Write(GetCompiled());
                }
            }
        }

        private void Compile_Clicked(object sender, EventArgs e)
        {
            saveToolStripMenuItem_Click(sender, e);

            if ((DialogResult)saver.Tag == DialogResult.OK)
            {
                using (Microsoft.CSharp.CSharpCodeProvider compiler = new Microsoft.CSharp.CSharpCodeProvider())
                {
                    System.CodeDom.Compiler.CompilerResults results = compiler.CompileAssemblyFromFile(
                        new System.CodeDom.Compiler.CompilerParameters(
                            Compiler.UsedAssemblies.Select(name => name.Location).ToArray(),
                            saver.FileName.Substring(0, saver.FileName.LastIndexOf('\\') + 1) + "a.exe",
                            true)
                            {
                                MainClass = "MyNamespace.Program",
                                GenerateExecutable = true
                            },
                        saver.FileNames
                        );

                    if (results.Errors.Count > 0)
                        foreach (var error in results.Errors)
                            MessageBox.Show(error.ToString());
                    else
                        MessageBox.Show(results.PathToAssembly);
                }
            }
        }

        private void previewCodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(GetCompiled());
        }

        private string GetCompiled()
        {
            return Compiler.Compile(mCommands.ToArray());
        }
    }
}
