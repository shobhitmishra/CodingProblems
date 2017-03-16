<Query Kind="Program" />

void Main()
{
	var ob = new Solution();
	var input = new int[] {};
	ob.ProductExceptSelf(input).Dump();
}

// Define other methods and classes here
public class Solution
{
	public int[] ProductExceptSelf(int[] nums)
	{
		var result = Enumerable.Repeat(1, nums.Length).ToArray();
		var product = 1;
		for (int i = 0; i < nums.Length; i++)
		{
			result[i] *= product;
			product *= nums[i];
		}
		product = 1;
		for (int i = nums.Length -1; i >= 0 ; i--)
		{
			result[i] *= product;
			product *= nums[i];
		}
		return result;
	}
}