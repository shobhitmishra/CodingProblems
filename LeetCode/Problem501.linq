<Query Kind="Program" />

void Main()
{
	var root = new TreeNode(2);
	
	var leftTree = new TreeNode(2);
	leftTree.right = new TreeNode(2);
	var leftLeftTree = new TreeNode(1);
	leftLeftTree.left = new TreeNode(1);
	leftLeftTree.left.left = new TreeNode(1);
	leftLeftTree.left.right = new TreeNode(1);
	leftTree.left = leftLeftTree;
	
	var rightTree = new TreeNode(2);
	rightTree.right = new TreeNode(3);
	rightTree.right.left = new TreeNode(3);
	rightTree.right.left.left = new TreeNode(3);
	//rightTree.right.left.left.right = new TreeNode(3);
	
	root.left = leftTree;
	root.right = rightTree;
	
//	var root = new TreeNode(1);
//	root.right = new TreeNode(2);
//	root.right.left = new TreeNode(2);
	var ob = new Solution();
	ob.FindMode(root).Dump();
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
	int globalMax = 0;
	int count = 0;
	int prev = int.MinValue;
	List<int> result = new List<int>();
	
	public int[] FindMode(TreeNode root)
	{	
		if (root == null) return new int[0];
		ModifiedInOrder(root);
		return result.ToArray();
	}
	
	private void ModifiedInOrder(TreeNode root)
	{
		if (root == null)
			return;
		
		ModifiedInOrder(root.left);	
		
		count = prev == root.val ? count + 1 : 1;		
		
		if (count > globalMax)
		{
			result.Clear();
			result.Add(root.val);
			globalMax = count;
		}
		else if (count == globalMax)
			result.Add(root.val);
		prev = root.val;
		
		ModifiedInOrder(root.right);			
	}
}