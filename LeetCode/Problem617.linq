<Query Kind="Program" />

void Main()
{
	var stack =  new Stack<int>();
	for (int i = 0; i < 10; i++)
	{
		stack.Push(i);
	}
	stack.Reverse().ToArray().Dump();
}

// Define other methods and classes here
 public class TreeNode {
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int x) { val = x; }
}

public class Solution
{
	public TreeNode MergeTrees(TreeNode t1, TreeNode t2)
	{
		if(t1 == null && t2 == null)
			return null;
		var t1val = t1 == null ? 0 : t1.val;
		var t2val = t2 == null ? 0 : t2.val;
		
		var node = new TreeNode(t1val + t2val);
		node.left = MergeTrees(t1?.left, t2?.left);
		node.right = MergeTrees(t1?.right, t2?.right);
		return node;
	}
}