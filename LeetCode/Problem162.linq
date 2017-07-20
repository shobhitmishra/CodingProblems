<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.IO.dll</Reference>
</Query>

void Main()
{
	var input = new int[] {7,6,5,4,3,2};
	var ob = new Solution();
	var peak = ob.FindPeakElement(input);
	input[peak].Dump();
}

// Define other methods and classes here
public class Solution
{
	public int FindPeakElement(int[] nums)
	{
		int start = 0;
		int end = nums.Length - 1;
		while (start <= end)
		{
			if(start == end)
				return start;
			if (start + 1 == end)
			{
				if(nums[start] > nums[end])
					return start;
				return end;
			}
			int mid = (start + end) / 2;
			if(nums[mid] > nums[mid -1] && nums[mid] > nums[mid + 1])
				return mid;
			else if(nums[mid] > nums[mid -1] && nums[mid] < nums[mid + 1])
				start = mid + 1;
			else
				end = mid - 1;
		}
		return end;
	}
}