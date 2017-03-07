<Query Kind="Program" />

void Main()
{
	var ob = new Solution();
	var nums = new int[] {1,2,3,4,5,6,7};
	for (int i = 1; i < 10; i++)
	{
		int[] copy = new int[nums.Length];
		Array.Copy(nums, copy, nums.Length);
		ob.Rotate(copy,  i);
		copy.Dump();
	}
}

// Define other methods and classes here
public class Solution 
{
    public void Rotate(int[] nums, int k) 
	{
		k = k % nums.Length;
        ReverseArray(nums, 0, nums.Length -1);
		ReverseArray(nums, 0, k - 1);
		ReverseArray(nums, k, nums.Length -1);
    }
	
	private void ReverseArray(int[] nums, int start, int end)
	{
		while(start < end)
		{
			int temp = nums[start];
			nums[start] = nums[end];
			nums[end] = temp;
			start++; end--;
		}
	}	
}