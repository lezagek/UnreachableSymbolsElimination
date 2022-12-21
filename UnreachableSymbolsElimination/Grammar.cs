using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnreachableSymbolsElimination
{
    internal class Grammar
    {
        HashSet<string> N;
        HashSet<string> T;
        Dictionary<string, HashSet<string>> P;
        string S;

        public Grammar(HashSet<string> N, HashSet<string> T, Dictionary<string, HashSet<string>> P, string S)
        {
            this.N = new HashSet<string>(N);
            this.T = new HashSet<string>(T);
            this.P = new Dictionary<string, HashSet<string>>(P);
            this.S = new string(S);
        }

        public void PrintGrammar()
        {
            Console.WriteLine("Grammar:");

            Console.Write("N: ");
            foreach (string s in this.N)
            {
                Console.Write(s + " ");
            }
            Console.WriteLine();

            Console.Write("T: ");
            foreach (string s in this.T)
            {
                Console.Write(s + " ");
            }
            Console.WriteLine();

            Console.WriteLine("P:");
            PrintRules();
            Console.WriteLine();
        }
        private void PrintRules()
        {
            for (int i = 0; i<P.Keys.Count; i++)
            {
                Console.Write(P.ElementAt(i).Key + "->");
                for (int j = 0; j< P.ElementAt(i).Value.Count; j++)
                {
                    string line = P.ElementAt(i).Value.ElementAt(j).Equals("") ? "lyambda" : P.ElementAt(i).Value.ElementAt(j);
                    Console.Write(line + "|");
                }
                Console.WriteLine();
            }
        }

        public void UnreachableSymbolsElimination()
        {
            HashSet<string> axiomValue = new HashSet<string>();
            P.TryGetValue(S, out axiomValue);

            HashSet<string> helper = new HashSet<string>();

            for (int i = 0; i<axiomValue.Count; i++)
            {
                for (int j = 0; j<axiomValue.ElementAt(i).Length; j++)
                {
                    helper.Add(axiomValue.ElementAt(i)[j].ToString());
                }
            }

            int index = 0;

            while (index<helper.Count)
            {
                if (N.Contains(helper.ElementAt(index)))
                {
                    HashSet<string> temp = new HashSet<string>();
                    P.TryGetValue(helper.ElementAt(index), out temp);
                    if (temp != null)
                    {
                        for (int i = 0; i < temp.Count; i++)
                        {
                            for (int j = 0; j < temp.ElementAt(i).Length; j++)
                            {
                                helper.Add(temp.ElementAt(i)[j].ToString());
                            }
                        }
                    }
                }

                index++;
            }

            T.IntersectWith(helper);
            N.IntersectWith(helper); N.Add(S);

            Dictionary<string, HashSet<string>> newP = new Dictionary<string, HashSet<string>>();

            for (int i = 0; i<P.Keys.Count; i++)
            {
                if (N.Contains(P.Keys.ElementAt(i)))
                {
                    HashSet<string> temp = new HashSet<string>();
                    P.TryGetValue(P.Keys.ElementAt(i), out temp);
                    newP.Add(P.Keys.ElementAt(i), temp);
                }
            }

            P = newP;
        }
    }
}
