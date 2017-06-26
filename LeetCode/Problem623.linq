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
	var newRoot = ob.AddOneRow(root, 10, 3);	
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
	public TreeNode AddOneRow(TreeNode root, int v, int d)
	{
		if (d == 1)
		{
			var newRoot = new TreeNode(v);
			newRoot.left = root;
			return newRoot;
		}

		var nodesAtdminusOne = GetNodesAtDepth(root, d - 1);
		// for each node create two nodes
		foreach (var element in nodesAtdminusOne)
		{
			var elementLeft = new TreeNode(v);
			var elementRight = new TreeNode(v);
			elementLeft.left = element.left;
			elementRight.right = element.right;
			
			element.left = elementLeft;
			element.right = elementRight;
		}
		return root;	
	}
	
	private IEnumerable<TreeNode> GetNodesAtDepth(TreeNode root, int depth)
	{
		int currentDepth = 1;
		var queue = new Queue<TreeNode>();
		queue.Enqueue(root);
		while (currentDepth < depth)
		{
			var qSize = queue.Count();
			for (int i = 0; i < qSize; i++)
			{
				var current = queue.Dequeue();
				if(current.left != null)
					queue.Enqueue(current.left);
				if(current.right != null)
					queue.Enqueue(current.right);
			}
			currentDepth++;
		}
		return queue;
	}
}