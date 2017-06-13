<Query Kind="Program" />

void Main()
{
	var input = new int[] {2,3,-2,4-8};
	var ob = new Solution();
	ob.MaxProduct(input).Dump();
}

// Define other methods and classes here
public class Solution
{
	public int MaxProduct(int[] nums)
	{		
		if(nums == null || nums.Length == 0)
			return 0;
		var min = new int[nums.Length];
		var max = new int[nums.Length];		
		int maxProduct = min[0] = max[0] = nums[0];
		for (int i = 1; i < nums.Length; i++)
		{
			var minP = min[i-1] * nums[i];
			var maxP = max[i-1] * nums[i];
			min[i] = Math.Min(nums[i], Math.Min(minP, maxP));			
			max[i] = Math.Max(nums[i], Math.Max(minP, maxP));
			maxProduct = Math.Max(maxProduct, max[i]);
		}
		return maxProduct;
	}
}