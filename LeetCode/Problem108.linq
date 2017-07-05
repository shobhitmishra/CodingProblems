<Query Kind="Program" />

void Main()
{
	var input = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9};
	var ob = new Solution();
	var root = ob.SortedArrayToBST(input);
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
	public TreeNode SortedArrayToBST(int[] nums)
	{
		return GetBSTFromArray(nums, 0, nums.Length -1);
	}
	
	private TreeNode GetBSTFromArray(int[] nums, int start, int end)
	{
		if(start > end)
			return null;
		if(start == end)
			return new TreeNode(nums[start]);
		var mid = (start + end) / 2;
		var root = new TreeNode(nums[mid]);
		root.left = GetBSTFromArray(nums, start, mid -1);
		root.right = GetBSTFromArray(nums, mid + 1, end);
		return root;
	}
}