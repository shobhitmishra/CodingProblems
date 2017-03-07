<Query Kind="Program" />

void Main()
{
	TreeNode root = new TreeNode(3);
	root.left = new TreeNode(5);
	root.right = new TreeNode(1);
	root.left.left = new TreeNode(6);
	root.left.right = new TreeNode(2);
	root.right.left = new TreeNode(0);
	root.right.right = new TreeNode(8);
	root.left.right.left = new TreeNode(7);
	root.left.right.right = new TreeNode(4);
	var ob = new Solution();
	ob.LowestCommonAncestor(root, root.left.left, root.left.right.left).Dump();
}

public class TreeNode
{
	public int val;
	public TreeNode left;
	public TreeNode right;
	public TreeNode(int x) { val = x; }
 }
 
public class Solution
{
	public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
	{
		if(root == null)
			return null;
		if(root == p || root == q)
			return root;
		
		TreeNode left = LowestCommonAncestor(root.left, p, q);
		TreeNode right = LowestCommonAncestor(root.right, p, q);
		
		// if both left and right are not null then it means one node was in 
		// in left of root and one was in right. In that case root is LCA.
		if(left != null && right != null)
			return root;
		
		// if left is null then the solution was in right
		return left == null ? right : left;
	}	
}