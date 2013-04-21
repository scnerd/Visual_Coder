using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Reflection;

namespace Visual_Coder
{
    public static class Compiler
    {
        public static Assembly[] UsedAssemblies = new Assembly[0];

        private struct VarReturnPair
        {
            public string VarName;
            public Node Node;

            public VarReturnPair(Node N, string Name)
            { Node = N; VarName = Name; }
        }

        public static string Compile(Node[] Commands)
        {
            UsedAssemblies = new Assembly[0];

            foreach (Node f in Commands)
            {
                if (!f.IsLinked())
                {
                    throw new InvalidOperationException("Unlinked commands exist: " + f.ToString());
                }
            }

            StringBuilder GeneratedCode = new StringBuilder();

            foreach(string namesp in GetRequiredNamespaces(Commands))
            {
                GeneratedCode.AppendFormat("using {0};\n", namesp);
            }

            GeneratedCode.AppendLine("namespace MyNamespace \n {");
            GeneratedCode.AppendLine("class Program \n {");
            GeneratedCode.AppendLine("static void Main(string[] args) \n {");

            Node[] OrderedCmds = GetOrderedFunctionCalls(Commands);

            char CurName = 'a';

            List<VarReturnPair> Vars = new List<VarReturnPair>();

            foreach (Node n in OrderedCmds)
            {
                if (n.OutputConnected().Length > 0)
                {
                    Vars.Add(new VarReturnPair(n, "" + CurName));
                    GeneratedCode.Append("var " + CurName++ + " = ");
                }
                // Append the string, where all format spacers are replaced with the variable name associated with the function call that was supposed
                // to get directed to that parameter
                GeneratedCode.Append(String.Format(n.GetFormatString(), n.InputConnected().Select(inp => Vars.Find(v => v.Node == inp).VarName).ToArray()));

                GeneratedCode.Append(";\n");
            }

            GeneratedCode.AppendLine("}\n}\n}");

            return GeneratedCode.ToString();
        }


        private class AdjacencyTableEntry
        {
            public Node Node;
            public List<Node> Incoming;

            public AdjacencyTableEntry(Node N)
            {
                Node = N;
                Incoming = N.InputConnected().ToList();
            }
        }

        private static Node[] GetOrderedFunctionCalls(Node[] Commands)
        {
            /*
             *  L ← Empty list that will contain the sorted elements
             *  S ← Set of all nodes with no incoming edges
             *  while S is non-empty do
             *      remove a node n from S
             *      insert n into L
             *      for each node m with an edge e from n to m do
             *          remove edge e from the graph
             *          if m has no other incoming edges then
             *              insert m into S
             *  if graph has edges then
             *      return error (graph has at least one cycle)
             *  else 
             *      return L (a topologically sorted order)
             */

            List<AdjacencyTableEntry> S = Commands.Select(f => new AdjacencyTableEntry(f)).ToList();

            List<Node> OrderedNodes = new List<Node>();

            AdjacencyTableEntry n, p;

            while (S.Any(e => e.Incoming.Count == 0))
            {
                n = S.First(e => e.Incoming.Count == 0);
                S.Remove(n);

                OrderedNodes.Add(n.Node);

                foreach (Node m in n.Node.OutputConnected())
                {
                    if (S.Any(q => q.Node == m))
                    {
                        p = S.First(q => q.Node == m);
                        p.Incoming.Remove(n.Node);

                        // Note that the expression in the condition already adds "m" to "S"
                    }
                }
            }

            if (OrderedNodes.Count != Commands.Length)
            {
                throw new InvalidExpressionException("There must've been a cycle somewhere in the expression");
            }
            else
                return OrderedNodes.ToArray();
        }

        private static string[] GetRequiredNamespaces(Node[] Commands)
        {
            HashSet<string> NeededNamespaces = new HashSet<string>();
            HashSet<Assembly> NeededAssemblies = new HashSet<Assembly>();

            foreach(Node n in Commands)
            {
                foreach(Type t in n.TypesUsed())
                {
                    NeededNamespaces.Add(t.Namespace);
                    NeededAssemblies.Add(t.Assembly);
                }
            }

            UsedAssemblies = UsedAssemblies
                .Concat(NeededAssemblies)
                .Distinct()
                .ToArray();

            return NeededNamespaces.ToList().OrderBy(s => s).ToArray();
        }
    }
}
