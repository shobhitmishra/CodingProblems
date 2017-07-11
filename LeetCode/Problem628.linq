<Query Kind="Program" />

void Main()
{
	
}

// Define other methods and classes here
public class Solution
{
	public int MaximumProduct(int[] nums)
	{
		Array.Sort(nums);
		var last = nums.Length - 1;
		var maxPositiveProduct = nums[last] * nums[last -1] * nums[last-2];
		if(nums[0] < 0 && nums[1] < 0)
			return Math.Max(maxPositiveProduct, nums[0] * nums[1] * nums[last]);
		return maxPositiveProduct;
	}
}