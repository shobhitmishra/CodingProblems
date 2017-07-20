<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.IO.dll</Reference>
</Query>

void Main()
{
	var input = new int[] { 2, 3, 3, 3, 3, 3, 3, 1};
	var ob = new Solution();
	ob.Search(input,2).Dump();
}

// Define other methods and classes here
public class Solution
{
	public bool Search(int[] nums, int target)
	{
		int low = 0;
		int high = nums.Length - 1;
		while (low <= high)
		{
			int mid = (low + high) / 2;
			
			if(nums[mid] == target)
				return true;

			if (nums[mid] < nums[high])
			{
				if(target > nums[mid] && target <= nums[high])
					low = mid + 1;
				else
					high = mid - 1;
			}
			else if (nums[mid] > nums[high])
			{
				if(target < nums[mid] && target >= nums[low])
					high = mid -1;
				else
					low = mid + 1;
			}
			else
				high--;
		}
		return false;
	}
}