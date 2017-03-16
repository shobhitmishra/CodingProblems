<Query Kind="Program" />

void Main()
{
	var ob = new Solution();
	var nums = new int[] { 1,3,3 };
	ob.FindMin(nums).Dump();
}

// Define other methods and classes here
public class Solution
{
	public int FindMin(int[] nums)
	{
		if(nums.Length == 1)
			return nums[0];
		int start = 0;
		int end = nums.Length - 1;
		while (start < end)
		{
			int mid = start + (end - start) / 2;
			int next = GetNext(nums,mid);
			int prev = GetPrev(nums,mid);
			if(nums[mid] < prev && nums[mid] < next)
				return nums[mid];
			else if(nums[mid] < nums[end])
				end = mid - 1;
			else
				start = mid + 1;
		}
		return Math.Min(nums[start], nums[end]);
	}

	public int GetNext(int[] nums, int index)
	{
		if(index + 1 < nums.Length)
			return nums[index+1];
		return nums[0];
	}

	public int GetPrev(int[] nums, int index)
	{
		if(index - 1 >= 0)
			return nums[index -1];
		else
			return nums[nums.Length -1];
	}
}