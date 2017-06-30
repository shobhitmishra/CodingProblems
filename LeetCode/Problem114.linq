<Query Kind="Program" />

void Main()
{
	var root = new TreeNode(1);

	var leftSubtree = new TreeNode(2);
	leftSubtree.left = new TreeNode(3);
	leftSubtree.right = new TreeNode(4);
	
	var rightSubTree = new TreeNode(5);	
	rightSubTree.right = new TreeNode(6);	
	
	root.left = leftSubtree;
	root.right = rightSubTree;
	
	var ob = new Solution();
	ob.Flatten(root);
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
	public void Flatten(TreeNode root)
	{
		FlattenInOrderHelper(root);
	}
	private TreeNode FlattenInOrderHelper(TreeNode root)
	{
		if (root == null)
			return null;
		
		var leftFlatten = FlattenInOrderHelper(root.left);
		var rightFlatten = FlattenInOrderHelper(root.right);

		root.left = root.right = null;
		return MergeLinkList(MergeLinkList(root, leftFlatten), rightFlatten);
	}

	private TreeNode MergeLinkList(TreeNode t1, TreeNode t2)
	{
		if(t1 == null)
			return t2;
		if(t2 == null)
			return t1;
		var t1Tail = GetTail(t1);		
		t1Tail.right = t2;
		return t1;
	}
	
	private TreeNode GetTail(TreeNode t1)
	{
		if(t1 == null)
			return null;
		var temp = t1;
		while(temp.right != null)
			temp = temp.right;
		return temp;
	}
}