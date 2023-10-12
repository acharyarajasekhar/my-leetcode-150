/*
*               1
*             / | \
*            2  5  9
*           /  / \   \
*          3  6   8   10
*         /  / 
*        4  7
*
*/

/* Stack

1 in & 1 out
2,5,9 in & 2 out
3 in & 3 out
4 in & 4 out
5 out
6, 8 in & 6 out
7 in & 7 out
8 out
9 out
10 in & 10 out

*/


public class TreeNode
{
    public int val;
    public List<TreeNode> chields;

    public TreeNode(int v)
    {
        val = v;
        chields = new List<TreeNode>();
    }
}

var n1 = new TreeNode(1);
var n2 = new TreeNode(2);
var n3 = new TreeNode(3);
var n4 = new TreeNode(4);
var n5 = new TreeNode(5);
var n6 = new TreeNode(6);
var n7 = new TreeNode(7);
var n8 = new TreeNode(8);
var n9 = new TreeNode(9);
var n10 = new TreeNode(10);

n1.chields.Add(n9);
n1.chields.Add(n5);
n1.chields.Add(n2);

n2.chields.Add(n3);

n3.chields.Add(n4);

n5.chields.Add(n8);
n5.chields.Add(n6);

n6.chields.Add(n7);

n9.chields.Add(n10);

var stk = new Stack<TreeNode>();
stk.Push(n1);

while (stk.Count > 0)
{
    var currentNode = stk.Pop();
    Console.WriteLine(currentNode.val);
    foreach (var child in currentNode.chields)
    {
        stk.Push(child);
    }
}

/* Using Recursions */

private void DFSHelper(TreeNode node) {
    Console.WriteLine(node.val);
    foreach(var chield in node.chields) {
        DFSHelper(chield);
    }
}

DFSHelper(n1);