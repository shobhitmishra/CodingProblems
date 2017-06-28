<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.IO.dll</Reference>
</Query>

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
	var newRoot = ob.FindFrequentTreeSum(root).Dump();
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
	public int[] FindFrequentTreeSum(TreeNode root)
	{
		if(root == null)
			return new int[0];
		var sumFrequency = new Dictionary<int,int>();
		ModifiedPostOrder(root, sumFrequency);
		var maxFrequency = sumFrequency.Values.Max();
		return sumFrequency.Where(x => x.Value == maxFrequency).Select(x => x.Key).ToArray();
	}
	
	private int ModifiedPostOrder(TreeNode root, Dictionary<int,int> sumFrequency)
	{
		if(root == null)
			return 0;
		var left = ModifiedPostOrder(root.left, sumFrequency);
		var right = ModifiedPostOrder(root.right, sumFrequency);
		
		var sumAtThisNode = root.val + left + right;
		if(!sumFrequency.ContainsKey(sumAtThisNode))
			sumFrequency.Add(sumAtThisNode, 0);
		sumFrequency[sumAtThisNode] +=1;
		
		return sumAtThisNode;
	}
}