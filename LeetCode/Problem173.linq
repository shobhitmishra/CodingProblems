<Query Kind="Program" />

void Main()
{
	
}

public class TreeNode
{
	public int val;
	public TreeNode left;
	public TreeNode right;
	public TreeNode(int x) { val = x; }
}

// Define other methods and classes here
public class BSTIterator
{
	Stack<TreeNode> stack = new Stack<TreeNode>();
	public BSTIterator(TreeNode root)
	{
		PushAll(root);
	}

	/** @return whether we have a next smallest number */
	public bool HasNext()
	{
		return stack.Count() != 0;
	}

	/** @return the next smallest number */
	public int Next()
	{
		var node = stack.Pop();
		PushAll(node.right);
		return node.val;
	}

	private void PushAll(TreeNode root)
	{
		while (root != null)
		{
			stack.Push(root);
			root = root.left;
		}
	}
}
