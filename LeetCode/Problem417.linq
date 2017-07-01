<Query Kind="Program" />

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
	ob.LevelOrderBottom(root).Dump();
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
	public IList<IList<int>> LevelOrderBottom(TreeNode root)
	{
		var stack = new Stack<IList<int>>();
		var q = new Queue<TreeNode>();
		if(root != null)
			q.Enqueue(root);
		while (q.Count() > 0)
		{
			var size = q.Count();
			var list = new List<int>();
			for (int i = 0; i < size; i++)
			{
				var node = q.Dequeue();
				list.Add(node.val);
				if(node.left != null)
					q.Enqueue(node.left);
				if(node.right != null)
					q.Enqueue(node.right);
			}
			stack.Push(list);
		}
		return stack.ToList();
	}
}