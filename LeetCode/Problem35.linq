<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.IO.dll</Reference>
</Query>

void Main()
{
	var input = new int[] { 1, 3, 5, 6};
	var ob = new Solution();
	ob.SearchInsert(input, 0).Dump();
}

// Define other methods and classes here
public class Solution
{
	public int SearchInsert(int[] nums, int target)
	{	
		if(nums.Length < 1)
			return 0;
		int start = 0;
		int end = nums.Length;
		while (start < end)
		{
			int mid = (start + end) / 2;
			if(nums[mid] == target)
				return mid;
			if(target < nums[mid])
				end = mid;
			else
				start = mid + 1;
		}
		return end;
	}
}