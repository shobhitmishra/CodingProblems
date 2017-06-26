<Query Kind="Program" />

void Main()
{
	var root = new TreeNode(10);

	var leftSubtree = new TreeNode(5);
	leftSubtree.left = new TreeNode(1);
	leftSubtree.right = new TreeNode(8);

	var rightSubTree = new TreeNode(20);
	rightSubTree.left = new TreeNode(15);
	rightSubTree.right = new TreeNode(25);
	rightSubTree.right.left = new TreeNode(22);
	rightSubTree.right.right = new TreeNode(30);

	root.left = leftSubtree;
	root.right = rightSubTree;

	var ob = new Solution();
	var newRoot = ob.LargestValues(root).Dump();
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
	// Do a level order traversal
	public IList<int> LargestValues(TreeNode root)
	{
		var result = new List<int>();
		if(root == null)
			return result;
		
		// we'll do a modified BFS
		var queue = new Queue<TreeNode>();
		queue.Enqueue(root);
		while (queue.Count() > 0)
		{
			var nodeAtThisLevel = queue.Count();
			var max = int.MinValue;
			for (int i = 0; i < nodeAtThisLevel; i++)
			{
				var current = queue.Dequeue();
				max = Math.Max(max, current.val);
				
				// Add its children
				if(current.left != null) 
					queue.Enqueue(current.left);
				if(current.right != null)
					queue.Enqueue(current.right);
			}
			result.Add(max);
		}
		
		return result;
	}	
}