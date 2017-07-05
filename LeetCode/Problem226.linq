<Query Kind="Program" />

void Main()
{
	var root = new TreeNode(1);

	var leftSubtree = new TreeNode(2);
	leftSubtree.left = new TreeNode(4);
	leftSubtree.right = new TreeNode(5);
	leftSubtree.left.left = new TreeNode(8);
	leftSubtree.left.right = new TreeNode(9);

	var rightSubTree = new TreeNode(3);
	rightSubTree.left = new TreeNode(6);
	rightSubTree.right = new TreeNode(7);
	rightSubTree.right.left = new TreeNode(10);
	rightSubTree.right.right = new TreeNode(11);

	root.left = leftSubtree;
	root.right = rightSubTree;

	var ob = new Solution();
	root = ob.InvertTree(root);
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
	public TreeNode InvertTree(TreeNode root)
	{
		InvertTreeHelper(root);
		return root;		
	}
	private void InvertTreeHelper(TreeNode root)
	{
		if (root != null)
		{
			var temp = root.left;
			root.left = root.right;
			root.right = temp;
			InvertTreeHelper(root.left);
			InvertTreeHelper(root.right);
		}
	}
}