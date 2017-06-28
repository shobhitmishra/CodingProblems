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

//	var root = new TreeNode(1);
//	root.left = new TreeNode(2);
	var ob = new Solution();
	ob.PostorderTraversal(root).Dump();
	ob.PreorderTraversal(root).Dump();
	ob.InOrderTraversal(root).Dump();
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
	public IList<int> InOrderTraversal(TreeNode root)
	{
		var result = new List<int>();
		var stack = new Stack<TreeNode>();
		var node = root;
		while (stack.Count() > 0 || node != null)
		{
			if (node == null)
			{
				var top = stack.Pop();
				result.Add(top.val);
				node = top.right;
			}
			else
			{
				stack.Push(node);
				node = node.left;
			}
		}
		return result;		
	}
	
	public IList<int> PostorderTraversal(TreeNode root)
	{
		var result = new Stack<int>();
		var stack = new Stack<TreeNode>();		
		var node = root;		
		while (stack.Count() > 0 || node != null)
		{
			if(node == null)
				node = stack.Pop();
			else
			{
				result.Push(node.val);
				if(node.left != null)
					stack.Push(node.left);
				node = node.right;
			}
		}
		return result.ToArray();
	}
	
	public IList<int> PreorderTraversal(TreeNode root)
	{
		var result = new List<int>();
		var stack = new Stack<TreeNode>();		
		var node = root;
		while (stack.Count() > 0 || node != null)
		{
			if(node == null)
				node = stack.Pop();
			else
			{
				result.Add(node.val);
				if(node.right != null)
					stack.Push(node.right);
				node = node.left;
			}
		}
		return result;
	}
}