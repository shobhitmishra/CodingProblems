<Query Kind="Program" />

void Main()
{
	var root = new TreeNode(10);

	var leftSubtree = new TreeNode(5);
	leftSubtree.left = new TreeNode(1);
	leftSubtree.right = new TreeNode(8);
	leftSubtree.right.left = new TreeNode(6);
	leftSubtree.right.right = new TreeNode(9);

	var rightSubTree = new TreeNode(20);
	rightSubTree.left = new TreeNode(15);
	rightSubTree.right = new TreeNode(40);
	rightSubTree.right.left = new TreeNode(30);
	rightSubTree.right.right = new TreeNode(70);

	root.left = leftSubtree;
	root.right = rightSubTree;

	//	var root = new TreeNode(1);
	//	root.left = new TreeNode(2);
	var ob = new Solution();
	ob.MaxPathSum(root).Dump();
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
	int globalSum = int.MinValue;
	public int MaxPathSum(TreeNode root)
	{
		MaxPathSumHelper(root);
		return globalSum;
	}	
	
	private int MaxPathSumHelper(TreeNode root)
	{
		if(root == null)
			return 0;
		
		var maxLeft = Math.Max(0, MaxPathSumHelper(root.left));
		var maxRight = Math.Max(0, MaxPathSumHelper(root.right));

		// max sum rooted here	
		globalSum = Math.Max(globalSum, root.val + maxLeft + maxRight);
		
		// for global path, we can either take left or right
		return Math.Max(maxLeft, maxRight) + root.val;
	}
}