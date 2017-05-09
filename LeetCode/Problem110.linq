<Query Kind="Program" />

void Main()
{
	TreeNode root = new TreeNode(16);
	root.left = new TreeNode(8);
	root.left.left = new TreeNode(4);
	root.left.left.left = new TreeNode(3);
	root.left.left.left.left = new TreeNode(2);
	root.left.left.left.left.left = new TreeNode(1);

	root.left.right = new TreeNode(12);

	root.right = new TreeNode(40);
	root.right.left = new TreeNode(20);
	root.right.left.left = new TreeNode(18);
	root.right.left.right = new TreeNode(30);

	root.right.right = new TreeNode(50);
	root.right.right.right = new TreeNode(60);
	root.right.right.right.right = new TreeNode(70);

	var ob = new Solution();
	ob.IsBalanced(root).Dump();
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
	public bool IsBalanced(TreeNode root)
	{
		return GetHeight(root) != -1;
	}

	private int GetHeight(TreeNode node)
	{
		if(node == null)
			return 0;
		
		int leftHt = GetHeight(node.left);
		if(leftHt == -1)
			return -1;
		
		int rightHt = GetHeight(node.right);
		if(rightHt == -1)
			return -1;
		
		if(Math.Abs(leftHt - rightHt) > 1)
			return -1;
			
		return 1 + Math.Max(leftHt, rightHt);
	}
}