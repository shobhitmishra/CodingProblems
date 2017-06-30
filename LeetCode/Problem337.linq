<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.IO.dll</Reference>
</Query>

void Main()
{
	var root = new TreeNode(3);
	
	var left = new TreeNode(4);
	left.left = new TreeNode(1);
	left.right = new TreeNode(3);
	
	var right = new TreeNode(5);
	right.right = new TreeNode(1);
	
	root.left = left;
	root.right = right;
	
	var ob = new Solution();
	ob.Rob(root).Dump();
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
	public int Rob(TreeNode root)
	{
		var result = RobHelper(root);
		return Math.Max(result[0], result[1]);
	}

	public int[] RobHelper(TreeNode root)
	{
		if (root == null)
			return new int[] { 0, 0};
		
		var leftResult = RobHelper(root.left);
		var rightResult = RobHelper(root.right);

		var includeResult = root.val + leftResult[1] + rightResult[1];
		var excludeResult = Math.Max(leftResult[0], leftResult[1]) + Math.Max(rightResult[0], rightResult[1]);

		return new int[] { includeResult, excludeResult};
	}
}