<Query Kind="Program" />

void Main()
{
	var root = new TreeNode(1);
	root.left = new TreeNode(2);
	root.right = new TreeNode(3);
	var ob = new Solution();
	ob.SumNumbers(null).Dump();
}


public class TreeNode 
{
	public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int x) { val = x; }
}

public class Solution
{
	int sum = 0;
	public int SumNumbers(TreeNode root)
	{
		string pathSoFar = "";
		Traverse(root, pathSoFar);
		return sum;
	}
	public void Traverse(TreeNode node, string pathSoFar)
	{
		if (node != null)
		{
			pathSoFar += node.val.ToString();
			if (IsLeaf(node))
			{
				int leafPathVal = Int32.Parse(pathSoFar);
				sum += leafPathVal;
			}
			else
			{
				Traverse(node.left, pathSoFar);
				Traverse(node.right, pathSoFar);
			}
		}
	}
	
	private bool IsLeaf(TreeNode node)
	{
		return node != null && node.left == null && node.right == null;
	}
}