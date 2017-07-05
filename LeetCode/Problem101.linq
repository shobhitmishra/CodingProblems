<Query Kind="Program" />

void Main()
{
	var root = new TreeNode(1);
	
	root.left = new TreeNode(2);
	//root.left.left = new TreeNode(3);
	root.left.right = new TreeNode(3);
	
	root.right = new TreeNode(2);
	//root.right.left = new TreeNode(4);
	root.right.right = new TreeNode(3);
	
	var ob = new Solution();
	ob.IsSymmetric(root).Dump();
}

public class TreeNode
{
	public int val;
	public TreeNode left;
	public TreeNode right;
	public TreeNode(int x) { val = x; }
}

// Define other methods and classes here
public class Solution
{
	public bool IsSymmetric(TreeNode root)
	{
		if(root == null)
			return true;
		return IsSymmetricHelper(root.left, root.right);
	}
	
	private bool IsSymmetricHelper(TreeNode a, TreeNode b)
	{
		if(a == null && b == null)
			return true;
		if(a == null || b == null)
			return false;
		if(a.val != b.val)
			return false;
		return IsSymmetricHelper(a.left, b.right) && IsSymmetricHelper(a.right, b.left);
	}
}