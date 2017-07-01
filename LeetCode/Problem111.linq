<Query Kind="Program" />

void Main()
{
	
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
	public int MinDepth(TreeNode root)
	{
		if(root == null)
			return 0;
		return MinDepthHelper(root);
	}
	private int MinDepthHelper(TreeNode root)
	{
		if(root.left == null && root.right == null)
			return 1;
		int result = int.MaxValue;
		if(root.left != null)
			result = Math.Min(result, MinDepthHelper(root.left));
		if(root.right != null)
			result = Math.Min(result, MinDepthHelper(root.right));
		return result + 1;
	}
}