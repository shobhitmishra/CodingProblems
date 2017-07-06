<Query Kind="Program" />

void Main()
{
	var root = new TreeNode(10);
	root.right = new TreeNode(-3);
	root.right.right = new TreeNode(11);
	
	var leftTree = new TreeNode(5);
	leftTree.right = new TreeNode(2);
	leftTree.right.right = new TreeNode(1);
	
	leftTree.left = new TreeNode(3);
	leftTree.left.left = new TreeNode(3);
	leftTree.left.right = new TreeNode(-2);
	
	root.left = leftTree;	
	
//	var root = new TreeNode(1);
//	root.right = new TreeNode(2);
//	root.right.right = new TreeNode(3);
//	root.right.right.right = new TreeNode(4);
//	root.right.right.right.right = new TreeNode(5);
	
	var ob = new Solution();
	ob.PathSum(root, 8).Dump();
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
	public int PathSum(TreeNode root, int sum)
	{
		if(root == null)
			return 0;
		return SumFromHere(root, sum, 0) + PathSum(root.left, sum) + PathSum(root.right, sum);
	}
	private int SumFromHere(TreeNode root, int sum, long sumsoFar)
	{
		if(root == null)
			return 0;
		sumsoFar += root.val;
		var count = sumsoFar == sum ? 1 : 0;
		return count + SumFromHere(root.left, sum , sumsoFar) + 
			SumFromHere(root.right, sum, sumsoFar);
	}
}