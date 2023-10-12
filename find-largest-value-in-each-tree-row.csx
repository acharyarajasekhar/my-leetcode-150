public class TreeNode
{
    public int val;
    public TreeNode left;
    public TreeNode right;

    public TreeNode(int v, TreeNode l = null, TreeNode r = null)
    {
        val = v;
        left = l;
        right = r;
    }
}

public int[] FindLargestValueinEachTreeRowMethod(TreeNode root)
{
    List<int> result = new List<int>();
    if (root == null) return result.ToArray();

    Queue<TreeNode> dfs_queue = new Queue<TreeNode>();
    dfs_queue.Enqueue(root);

    while (dfs_queue.Count > 0)
    {
        int max_value = Int32.MinValue;
        int elements_count = dfs_queue.Count;
        for (int i = 0; i < elements_count; i++)
        {
            TreeNode node = dfs_queue.Dequeue();
            max_value = Math.Max((int)max_value, (int)node.val);
            if (node.left != null) dfs_queue.Enqueue(node.left);
            if (node.right != null) dfs_queue.Enqueue(node.right);
        }
        result.Add(max_value);
    }

    return result.ToArray();

}

TreeNode n5 = new TreeNode(5);
TreeNode n_3 = new TreeNode(3);
TreeNode n9 = new TreeNode(9);
TreeNode n3 = new TreeNode(3, n5, n_3);
TreeNode n2 = new TreeNode(2, null, n9);
TreeNode n1 = new TreeNode(1, n3, n2);

var result = FindLargestValueinEachTreeRowMethod(n1);

foreach (var r in result)
{
    Console.WriteLine(r);
}