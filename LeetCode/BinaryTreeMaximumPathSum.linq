<Query Kind="Program" />

void Main()
{
	int[] arr = new int[] {-1, 1, -2, 3, 1, -2, -3};
	var ob = new Solution();
	Console.WriteLine(ob.FindMaxSumSubarray(arr));
}

public class TreeNode 
{
	public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int x) { val = x; }
}
// Define other methods and classes here
public class Solution 
{
	List<int> inOrderTraversalArray = new List<int>();
    public int MaxPathSum(TreeNode root) 
	{
        InOrderTraversal(root);
		return FindMaxSumSubarray(inOrderTraversalArray.ToArray());
    }
	private void InOrderTraversal(TreeNode root)
	{
		if( root!= null)
		{
			InOrderTraversal(root.left);
			inOrderTraversalArray.Add(root.val);
			InOrderTraversal(root.right);
		}
	}
	public int FindMaxSumSubarray(int[] arr)
	{
		int currSum = arr[0];
		int GlobalSum = arr[0];
		for (int i = 1; i < arr.Length; i++)
		{
			currSum = Math.Max(arr[i], currSum + arr[i]);
			GlobalSum = Math.Max(GlobalSum, currSum);
		}
		return GlobalSum;
	}
}