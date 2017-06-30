<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.IO.dll</Reference>
</Query>

void Main()
{
	var root = new TreeNode(5);
	
	var leftTree = new TreeNode(4);
	leftTree.left = new TreeNode(11);
	leftTree.left.left = new TreeNode(7);
	leftTree.left.right = new TreeNode(2);
	
	var rightTree = new TreeNode(8);
	rightTree.left = new TreeNode(13);
	rightTree.right = new TreeNode(4);
	rightTree.right.left = new TreeNode(5);
	rightTree.right.right = new TreeNode(1);
	
	root.left = leftTree;
	root.right = rightTree;
	
	var ob = new Solution();
	ob.PathSum(root, 22).Dump();
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
	public IList<IList<int>> PathSum(TreeNode root, int sum)
	{
		var result = new List<IList<int>>();
		PathSumHelper(root, sum, new List<int>(), result);
		return result;
	}

	private void PathSumHelper(TreeNode root, int sum, List<int> pathSoFar, List<IList<int>> result)
	{
		if (root != null)
		{
			sum -= root.val;
			var temp = new List<int>(pathSoFar);
			temp.Add(root.val);

			if (sum == 0 && IsLeaf(root))
			{
				result.Add(temp);
				return;
			}
			PathSumHelper(root.left, sum, temp, result);
			PathSumHelper(root.right, sum, temp, result);
		}
	}

	private bool IsLeaf(TreeNode root)
	{
		if (root != null)
		{
			if (root.left == null && root.right == null)
				return true;
		}
		return false;
	}
}