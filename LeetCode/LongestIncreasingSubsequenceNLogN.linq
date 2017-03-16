<Query Kind="Program" />

void Main()
{
	var ob = new Solution();
	var nums = new int[] {3,5,6,2,5,4,19,5,6,7,12};
	ob.LengthOfLIS(nums).Dump();
}

// Define other methods and classes here
public class Solution
{
	int FindCeiling(int[] nums, int key)
	{
		if (key < nums[0])
			return 0;
		int left = 0;
		int right = nums.Length - 1;
		while (left < right)
		{
			int mid = (left + right) / 2;
			if (nums[mid] <= key && nums[mid + 1] > key)
				return mid + 1;
			else if (nums[mid] > key && nums[mid - 1] <= key)
				return mid;
			else if (nums[mid] <= key)
				left = mid + 1;
			else
				right = mid - 1;
		}
		return -1;
	}
	public int LengthOfLIS(int[] nums)
	{
		if (nums.Length == 0)
			return 0;
		var longest = new List<int>() { nums[0]};
		for (int i = 1; i < nums.Length; i++)
		{
			//if current number is largest 
			if(nums[i] > longest[longest.Count() -1])
				longest.Add(nums[i]);
			else
			{
				int ceil = FindCeiling(longest.ToArray(), nums[i]);
				if(ceil != -1)
					longest[ceil] = nums[i];
			}
		}
		return longest.Count();
	}
}