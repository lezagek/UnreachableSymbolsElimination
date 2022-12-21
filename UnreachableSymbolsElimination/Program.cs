using UnreachableSymbolsElimination;

Dictionary<string, HashSet<string>> P = new Dictionary<string, HashSet<string>>();
HashSet<string> N = new HashSet<string>();
HashSet<string> T = new HashSet<string>();



//------------------------------------------------------------------------------------ТЕСТ 1

//HashSet<string> test11 = new HashSet<string>();
//HashSet<string> test12 = new HashSet<string>();
//HashSet<string> test13 = new HashSet<string>();

//N.Add("E");
//N.Add("T");
//N.Add("F");
//T.Add("a");
//T.Add("+");
//T.Add("*");
//T.Add("(");
//T.Add(")");

//test11.Add("E+T");
//test11.Add("T");
//P.Add("E", test11);

//test12.Add("T*F");
//test12.Add("F");
//P.Add("T", test12);

//test13.Add("(E)");
//test13.Add("a");
//P.Add("F", test13);

//------------------------------------------------------------------------------------ТЕСТ 2

//HashSet<string> test21 = new HashSet<string>();
//HashSet<string> test22 = new HashSet<string>();
//HashSet<string> test23 = new HashSet<string>();

//N.Add("S");
//N.Add("A");
//N.Add("B");
//T.Add("a");
//T.Add("b");

//test21.Add("a");
//test21.Add("A");
//P.Add("S", test21);

//test22.Add("AB");
//P.Add("A", test22);

//test23.Add("b");
//P.Add("B", test23);

//------------------------------------------------------------------------------------ТЕСТ 3

//HashSet<string> test31 = new HashSet<string>();
//HashSet<string> test32 = new HashSet<string>();
//HashSet<string> test33 = new HashSet<string>();

//N.Add("S");
//N.Add("A");
//N.Add("D");
//T.Add("a");
//T.Add("c");

//test31.Add("Ac");
//P.Add("S", test31);

//test32.Add("SD");
//test32.Add("a");
//P.Add("A", test32);

//test33.Add("aD");
//P.Add("D", test33);

//------------------------------------------------------------------------------------ТЕСТ 4

//HashSet<string> test41 = new HashSet<string>();
//HashSet<string> test42 = new HashSet<string>();
//HashSet<string> test43 = new HashSet<string>();
//HashSet<string> test44 = new HashSet<string>();

//N.Add("S");
//N.Add("A");
//N.Add("B");
//N.Add("C");
//N.Add("D");
//N.Add("E");
//N.Add("F");
//N.Add("G");
//T.Add("c");

//test41.Add("AB");
//test41.Add("CD");
//P.Add("S", test41);

//test42.Add("EF");
//P.Add("A", test42);

//test43.Add("AD");
//P.Add("G", test43);

//test44.Add("c");
//P.Add("C", test44);

//------------------------------------------------------------------------------------ТЕСТ 5

HashSet<string> test51 = new HashSet<string>();
HashSet<string> test52 = new HashSet<string>();
HashSet<string> test53 = new HashSet<string>();
HashSet<string> test54 = new HashSet<string>();

N.Add("S");
N.Add("A");
N.Add("B");
N.Add("E");
N.Add("F");
T.Add("a");
T.Add("c");
T.Add("f");
T.Add("s");

test51.Add("AS");
test51.Add("BS");
test51.Add("s");
P.Add("S", test51);

test52.Add("EF");
test52.Add("FF");
P.Add("E", test52);

test53.Add("a");
P.Add("A", test53);

test54.Add("f");
P.Add("F", test54);

Grammar G = new Grammar(N, T, P, "S");
Console.Write("Old ");  G.PrintGrammar();
G.UnreachableSymbolsElimination();
Console.WriteLine();
Console.Write("New "); G.PrintGrammar();
