<Query Kind="Program" />

void Main()
{
	
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
	public IList<int> RightSideView(TreeNode root)
	{
		var result = new List<int>();
		if (root == null)
			return result;
		LevelOrderTraversal(root, result);
		return result;
	}

	private void LevelOrderTraversal(TreeNode root, List<int> result)
	{
		var q = new Queue<TreeNode>();
		q.Enqueue(root);
		while (q.Count() > 0)
		{
			TreeNode last = null;
			int size = q.Count();
			for (int i = 0; i < size; i++)
			{
				last = q.Dequeue();
				if (last.left != null)
					q.Enqueue(last.left);
				if (last.right != null)
					q.Enqueue(last.right);
			}
			result.Add(last.val);
		}
	}
}