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
	public string Tree2str(TreeNode t)
	{
		if (t == null)
			return "";

		var left = Tree2str(t.left);
		var right = Tree2str(t.right);

		var val = t.val.ToString();

		if (string.IsNullOrWhiteSpace(left) && string.IsNullOrWhiteSpace(right))
			return val;
		if (string.IsNullOrWhiteSpace(left))
			return val + "()" + $"({right})";
		if (string.IsNullOrWhiteSpace(right))
			return val + $"({left})";

		return val + $"({left})" + $"({right})";
	}
}