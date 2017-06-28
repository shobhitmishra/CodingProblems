<Query Kind="Program" />

void Main()
{
	var ob = new Solution();
	var input = new int[] {-2,1,-3,4,-1,2,1,-5,4};
	ob.MaxSubArray(input).Dump();
}

// Define other methods and classes here
public class Solution
{
	public int MaxSubArray(int[] nums)
	{
		var prevSum = nums[0];
		var globalSum = nums[0];
		for (int i = 1; i < nums.Length; i++)
		{
			var num = nums[i];
			prevSum = Math.Max(num, num + prevSum);
			globalSum = Math.Max(prevSum, globalSum);
		}		
		return globalSum;
	}	
}