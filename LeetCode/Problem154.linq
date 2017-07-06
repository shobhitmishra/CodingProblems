<Query Kind="Program" />

void Main()
{
	var input = new int[] {4,5,6,7,0,1,2,2,2,2,2,2,2,2};
	var ob = new Solution();
	ob.FindMin(input).Dump();
}

// Define other methods and classes here
public class Solution
{
	public int FindMin(int[] nums)
	{
		int low = 0;
		int high = nums.Length - 1;
		
		while (low < high)
		{
			var mid = (low + high) / 2;
			if(nums[mid] > nums[high])
				low = mid + 1;
			else if(nums[mid] < nums[high])
				high = mid;
			else
				high--;
		}
		return nums[low];
	}
}