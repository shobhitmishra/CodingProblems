<Query Kind="Program" />

void Main()
{
	int[] nums = new int[] { 10, 9, 2};
	var ob = new Solution();
	ob.LengthOfLIS(nums).Dump("Max length");
}

// Define other methods and classes here
public class Solution
{
	public int LengthOfLIS(int[] nums)
	{
		if(nums.Length == 0)
			return 0;
		var lisLength = Enumerable.Repeat(1, nums.Length).ToArray();
		for (int i = 0; i < nums.Length; i++)
		{
			for (int j = 0; j < i; j++)
			{
				if(nums[i] > nums[j])
					lisLength[i] = Math.Max(lisLength[i], lisLength[j] + 1);
			}
		}
		return lisLength.Max();
	}
}