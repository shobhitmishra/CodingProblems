<Query Kind="Program" />

void Main()
{
	var input = new int[] { 1,3,2,2,2};
	var ob = new Solution();
	ob.FindUnsortedSubarray(input).Dump();
}

// Define other methods and classes here
public class Solution
{
	public int FindUnsortedSubarray(int[] nums)
	{
		if(nums.Length < 2)
			return 0;
		int left = nums.Length -1;
		int minOnRight = int.MaxValue;
		for (int i = nums.Length -1; i >= 0 ; i--)
		{
			minOnRight = Math.Min(minOnRight, nums[i]);
			if(minOnRight < nums[i])
				left = i;
		}
		
		int right = 0;
		int maxOnLeft = int.MinValue;
		for (int i = 0; i < nums.Length; i++)
		{
			maxOnLeft = Math.Max(maxOnLeft, nums[i]);
			if(maxOnLeft > nums[i])
				right = i;
		}
		
		return Math.Min(0,right - left + 1);
	}
}