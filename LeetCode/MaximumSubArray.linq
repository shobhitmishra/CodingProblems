<Query Kind="Program" />

void Main()
{
	var input = new int[] {-2, 1, -3, 4, -1, 2, 1,-5, 4};
	var ob = new Solution();
	ob.MaxSubArray(input).Dump();
}

// Define other methods and classes here
public class Solution
{
	public int MaxSubArray(int[] nums)
	{
		var maxHere = new int[nums.Length];
		var maxSoFar = nums[0];		
		maxHere[0] = nums[0] > 0 ? nums[0]: 0;
		
		for (int i = 1; i < nums.Length; i++)
		{
			maxHere[i] = maxHere[i-1] + nums[i];
			maxSoFar = Math.Max(maxHere[i], maxSoFar);
			if(maxHere[i] < 0)
				maxHere[i] = 0;
		}
		return maxSoFar;
	}
}