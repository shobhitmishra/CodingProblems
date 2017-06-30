<Query Kind="Program" />

void Main()
{
	var root = new TreeNode(10);

	var leftSubtree = new TreeNode(5);
	leftSubtree.left = new TreeNode(1);
	leftSubtree.right = new TreeNode(8);
	leftSubtree.right.left = new TreeNode(6);
	leftSubtree.right.right = new TreeNode(9);

	var rightSubTree = new TreeNode(20);
	rightSubTree.left = new TreeNode(15);
	rightSubTree.right = new TreeNode(40);
	rightSubTree.right.left = new TreeNode(30);
	rightSubTree.right.right = new TreeNode(70);

	root.left = leftSubtree;
	root.right = rightSubTree;

	var ob = new Solution();
	ob.ZigzagLevelOrder(root).Dump();
	
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
	public IList<IList<int>> ZigzagLevelOrder(TreeNode root)
	{
		var result = new List<IList<int>>();
		if(root == null)
			return result;
		var q = new Queue<TreeNode>();
		q.Enqueue(root);
		var leftToRight = true;
		while (q.Count() > 0)
		{
			var size = q.Count();
			var levelNodes = new List<int>();
			for (int i = 0; i < size; i++)
			{
				var node = q.Dequeue();
				if(leftToRight)
					levelNodes.Add(node.val);
				else
					levelNodes.Insert(0,node.val);
				
				if(node.left != null)
					q.Enqueue(node.left);
				if(node.right != null)
					q.Enqueue(node.right);
			}			
			result.Add(levelNodes);
			leftToRight = !leftToRight;
		}
		return result;
	}	
}