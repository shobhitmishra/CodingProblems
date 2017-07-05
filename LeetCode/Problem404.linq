<Query Kind="Program" />

void Main()
{
	var root = new TreeNode(3);
	root.left = new TreeNode(9);
	root.right = new TreeNode(20);
	root.right.left = new TreeNode(15);
	root.right.right = new TreeNode(7);
	var ob = new Solution();
	ob.SumOfLeftLeaves(root).Dump();
}

// Define other methods and classes here
public class TreeNode
{
	public int val;
	public TreeNode left;
	public TreeNode right;
	public TreeNode(int x) { val = x; }
}

public class Solution
{
	int sum = 0;
	public int SumOfLeftLeaves(TreeNode root)
	{
		InOrderTraversal(root);
		return sum;
	}
	private void InOrderTraversal(TreeNode root)
	{
		if (root != null)
		{
			if(IsLeaf(root.left))
				sum += root.left.val;
			InOrderTraversal(root.left);
			InOrderTraversal(root.right);
		}
	}
	private bool IsLeaf(TreeNode root)
	{
		if(root != null && root.left == null && root.right == null)
			return true;
		return false;
	}
}