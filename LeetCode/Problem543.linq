<Query Kind="Program" />

void Main()
{
	var root = new TreeNode(1);

	var leftSubtree = new TreeNode(2);
	leftSubtree.left = new TreeNode(3);
	leftSubtree.right = new TreeNode(4);

	var rightSubTree = new TreeNode(5);
	rightSubTree.left = new TreeNode(6);
	rightSubTree.right = new TreeNode(7);
	rightSubTree.right.right = new TreeNode(8);

	root.left = leftSubtree;
	root.right = rightSubTree;

	var ob = new Solution();
	ob.DiameterOfBinaryTree(root).Dump();
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
	int diameter = 0;
	public int DiameterOfBinaryTree(TreeNode root)
	{
		if(root == null)
			return 0;
		GetHeight(root);
		return diameter;
	}
	
	private int GetHeight(TreeNode root)
	{
		if(root == null)
			return 0;
		var leftHeight = GetHeight(root.left);
		var rightHeight = GetHeight(root.right);
		diameter = Math.Max(diameter, leftHeight + rightHeight);
		return 1 + Math.Max(leftHeight,rightHeight);
	}
}