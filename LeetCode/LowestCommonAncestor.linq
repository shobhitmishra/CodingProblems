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




// Define other methods and classes here
public class Solution
{
	public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
	{
		if(root == null)
			return null;
		// we need to find a node such that root sits between p and q;
		TreeNode lesser = p.val < q.val ? p : q;
		TreeNode greater = p.val > q.val ? p : q;
		
		if(lesser.val <= root.val && greater.val >= root.val)
			return root;
		if(lesser.val < root.val && greater.val < root.val)
			return LowestCommonAncestor(root.left, p, q);
		if(lesser.val > root.val && greater.val > root.val)
			return LowestCommonAncestor(root.right, p, q);
		return null;
	}
}