<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.IO.dll</Reference>
</Query>

void Main()
{
	var root = new TreeNode(30);

	var leftSubtree = new TreeNode(10);
	leftSubtree.left = new TreeNode(5);
	leftSubtree.right = new TreeNode(20);
	leftSubtree.right.left = new TreeNode(17);	

	var rightSubTree = new TreeNode(60);
	rightSubTree.left = new TreeNode(50);
	rightSubTree.left.right = new TreeNode(55);
	
	rightSubTree.right = new TreeNode(70);	
	rightSubTree.right.right = new TreeNode(80);

	root.left = leftSubtree;
	root.right = rightSubTree;

	var ob = new Solution();
	ob.DeleteNode(root, 30);
	InOrderTraversal(root);
}

public void InOrderTraversal(TreeNode root)
{
	if (root != null)
	{
		InOrderTraversal(root.left);
		Console.Write(root.val + "\t");
		InOrderTraversal(root.right);
	}
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
	public TreeNode DeleteNode(TreeNode root, int key)
	{
		if(root == null)
			return null;
		var searchResult = SearchNode(root, key);
		var node = searchResult[0];
		var parent = searchResult[1];
		
		// node not found
		if(node == null)
			return root;
		
		if (IsLeaf(node))
		{
			if (node == root)
				return null;			
		}
		
		DeleteNodeHelper(root, node, parent);
		
		return root;
	}
	
	private void DeleteNodeHelper(TreeNode root, TreeNode node, TreeNode parent)
	{
		if (IsLeaf(node))
		{
			if (parent.left == node)
				parent.left = null;
			else
				parent.right = null;
		}
		// if two children
		else if (node.left != null && node.right != null)
		{
			var temp = node.right.left;
			var successor = node.right;
			var successorParent = node;
			while (temp != null)
			{
				successorParent = successor;
				successor = temp;
				temp = temp.left;
			}
			
			// copy the value of successor into node
			node.val = successor.val;
			DeleteNodeHelper(root, successor, successorParent);
		}

		// if one child
		else
		{
			var child = node.left != null ? node.left : node.right;
			node.val = child.val;
			node.left = child.left;
			node.right = child.right;
		}
	}

	private bool IsLeaf(TreeNode root)
	{
		if(root != null && root.left == null && root.right == null)
			return true;
		return false;
	}
	
	private List<TreeNode> SearchNode(TreeNode root, int key)
	{
		TreeNode parent = null;
		var current = root;
		while (current != null)
		{
			if(current.val == key)
				break;
			parent = current;
			if (current.val < key)			
				current = current.right;
			else
				current = current.left;		
		}
		
		return new List<TreeNode>() { current, parent};
	}
}