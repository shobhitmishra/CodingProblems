<Query Kind="Program" />

void Main()
{
	var root = new TreeNode(10);

	var leftSubtree = new TreeNode(20);
	leftSubtree.left = new TreeNode(1);
	leftSubtree.right = new TreeNode(8);
	leftSubtree.right.left = new TreeNode(6);
	leftSubtree.right.right = new TreeNode(9);

	var rightSubTree = new TreeNode(5);
	rightSubTree.left = new TreeNode(15);
	rightSubTree.right = new TreeNode(40);
	rightSubTree.right.left = new TreeNode(30);
	rightSubTree.right.right = new TreeNode(70);

	root.left = leftSubtree;
	root.right = rightSubTree;
	
	
	var ob = new Solution();
	InOrderTraversal(root);
	Console.WriteLine("");
	ob.RecoverTree(root);
	Console.WriteLine("");
	InOrderTraversal(root);
}

// Define other methods and classes here
public class TreeNode
{
	public int val;
	public TreeNode left;
	public TreeNode right;
	public TreeNode(int x) { val = x; }
}

public void InOrderTraversal(TreeNode root)
{
	if (root != null)
	{
		InOrderTraversal(root.left);
		Console.Write("{0}\t", root.val);
		InOrderTraversal(root.right);
	}
}

public class Solution
{
	TreeNode node1, node2;
	TreeNode prevElement = new TreeNode(int.MinValue);
	public void RecoverTree(TreeNode root)
	{
		InOrder(root);		
		var temp = node1.val;
		node1.val = node2.val;
		node2.val = temp;
	}
	
	private void InOrder(TreeNode root)
	{
		if (root != null)
		{			
			InOrder(root.left);
			
			if(node1 == null && root.val <= prevElement.val)
				node1 = prevElement;
				
			if(node1 != null && root.val <= prevElement.val)
				node2 = root;
			
			Console.WriteLine(prevElement.val + " " + root.val);
			prevElement = root;
			
			InOrder(root.right);		
		}		
	}
}