<Query Kind="Program" />

void Main()
{
	var ob = new Solution();
	var input = new int[] { 8, 8, 8, 8};
	ob.SearchRange(input, 8).Dump();;
}

// Define other methods and classes here
public class Solution
{
	public int[] SearchRange(int[] nums, int target)
	{
		int lastOccurence = FindLast(nums,target);
		if (lastOccurence == -1)
			return new int[] { -1, -1};
		int firstOccurence = FindFirst(nums, target);
		return new int[] { firstOccurence, lastOccurence};
	}
	
	private int FindLast(int[] nums, int target)
	{
		int first = 0;
		int last = nums.Length - 1;
		while (first <= last)
		{
			int mid = first + (last - first) / 2;
			if (nums[mid] == target)
			{
				if(mid == nums.Length -1)
					return nums.Length - 1;
				if(nums[mid + 1] > target)
					return mid;
				else
					first = mid + 1;
			}
			else if (nums[mid] < target)
				first = mid + 1;			
			else
				last = mid - 1;
		}
		return -1;
	}

	private int FindFirst(int[] nums, int target)
	{
		int first = 0;
		int last = nums.Length - 1;
		while (first <= last)
		{
			int mid = first + (last - first) / 2;
			if (nums[mid] == target)
			{
				if (mid == 0)
					return 0;
				if (nums[mid - 1] < target)
					return mid;
				else
					last = mid - 1;
			}
			else if (nums[mid] < target)
				first = mid + 1;
			else
				last = mid - 1;
		}
		return -1;
	}
}