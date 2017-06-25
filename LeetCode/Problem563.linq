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
	ob.FindTilt(root).Dump();
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
	int totalTilt = 0;
	// every node returns sum of all the nodes including itself
	public int FindTilt(TreeNode root)
	{
		if(root == null)
			return 0;
		
		FindTiltHelper(root);
		return totalTilt;
	}

	public int FindTiltHelper(TreeNode root)
	{
		if (root == null)
			return 0;

		var leftSum = FindTiltHelper(root.left);
		var rightSum = FindTiltHelper(root.right);

		totalTilt += Math.Abs(leftSum - rightSum);
		return root.val + leftSum + rightSum;
	}
}