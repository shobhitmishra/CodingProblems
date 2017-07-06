<Query Kind="Program" />

void Main()
{
	var input = new int[] { 10, 11, 0, 1, 2, 4, 5, 6, 7, 8, 9, };
	var ob = new Solution();
	ob.FindMin(input).Dump();
}

// Define other methods and classes here
public class Solution
{
	public int FindMin(int[] nums)
	{
		int start = 0;
		int end = nums.Length - 1;
		while (start < end)
		{
			int mid = (start + end) / 2;
			if (nums[end] > nums[mid])
				end = mid;
			else
				start = mid + 1;
		}
		return nums[start];
	}
}