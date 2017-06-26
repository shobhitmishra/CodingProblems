<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.IO.dll</Reference>
</Query>

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
	var newRoot = ob.FindBottomLeftValue(root).Dump();
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
	// Do a level order traversal from right to left and return the 
	// last node's value
	public int FindBottomLeftValue(TreeNode root)
	{		
		var queue = new Queue<TreeNode>();
		queue.Enqueue(root);
		while (queue.Count() > 0)
		{
			var qSize = queue.Count();
			for (int i = 0; i < qSize; i++)
			{
				root = queue.Dequeue();				
				if (root.right != null)
					queue.Enqueue(root.right);
				if (root.left != null)
					queue.Enqueue(root.left);
			}			
		}
		return root.val;
	}	
}