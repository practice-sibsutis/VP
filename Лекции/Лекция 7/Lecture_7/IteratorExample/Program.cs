// See https://aka.ms/new-console-template for more information
using IteratorExample;

BinaryTree<string, int> tree = new BinaryTree<string, int>();
tree.Add("ten", 10);
tree.Add("nine", 9);
tree.Add("eight", 8);
tree.Add("seven", 7);
tree.Add("six", 6);
tree.Add("five", 5);
tree.Add("four", 4);
tree.Add("three", 3);
tree.Add("two", 2);
tree.Add("one", 1);
tree.Add("eleven", 11);
tree.Add("twelve", 12);
tree.Add("thirteen", 13);
tree.Add("fourteen", 14);
tree.Add("fifteen", 15);
tree.Add("sixteen", 16);
tree.Add("seventeen", 17);
tree.Add("eighteen", 18);
tree.Add("nineteen", 19);

foreach (KeyValuePair<string, int> pair in tree)
{
    Console.WriteLine(pair.Key, pair.Value);
}
