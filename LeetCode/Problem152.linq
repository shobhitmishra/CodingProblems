<Query Kind="Program" />

void Main()
{
	
}

// Define other methods and classes here
public class Solution
{
	public int MaxProduct(int[] nums)
	{
		var maxPre = nums[0];
		var minPre = nums[0];
		var max = nums[0];
		for (int i = 1; i < nums.Length; i++)
		{
			var num = nums[i];
			var maxHere = Math.Max(Math.Max(maxPre *num, minPre * num), nums[i]);
			var minHere = Math.Min(Math.Min(maxPre *num, minPre * num), nums[i]);
			max = Math.Max(max, maxHere);
			maxPre = maxHere;
			minPre = minHere;
		}
		return max;
	}
}