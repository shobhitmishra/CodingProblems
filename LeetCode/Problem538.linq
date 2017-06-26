<Query Kind="Program" />

void Main()
{
	var root = new TreeNode(10);

	var leftSubtree = new TreeNode(5);
	leftSubtree.left = new TreeNode(1);
	leftSubtree.right = new TreeNode(8);

	var rightSubTree = new TreeNode(20);
	rightSubTree.left = new TreeNode(15);
	rightSubTree.right = new TreeNode(25);
	rightSubTree.right.left = new TreeNode(22);
	rightSubTree.right.right = new TreeNode(30);

	root.left = leftSubtree;
	root.right = rightSubTree;

	var ob = new Solution();
	var newRoot = ob.ConvertBST(root).Dump();
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
	public TreeNode ConvertBST(TreeNode root)
	{		
		ConvertBSTHelper(root);
		return root;
	}
	
	public void ConvertBSTHelper(TreeNode root)
	{
		if (root != null)
		{
			ConvertBSTHelper(root.right);
			sum += root.val;
			root.val = sum;
			ConvertBSTHelper(root.left);
		}
	}
}