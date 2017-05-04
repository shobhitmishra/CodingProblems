<Query Kind="Program" />

void Main()
{
	var input = new int[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 0 };
	var ob = new Solution();
	for (int i = 0; i <= 10; i++)
	{
		var index = ob.Search(input, i);
		if(index == -1)
			Console.WriteLine("Couldn't find");
		else
			Console.WriteLine("{0} \t {1} \t {2}",i, input[index], index);
	}
	//ob.Search(input, 1).Dump();
}

// Define other methods and classes here
public class Solution
{
	public int Search(int[] nums, int target)
	{
		int l = 0;
		int r = nums.Length - 1;
		while (l <= r)
		{
			int mid = l + (r - l)/2;
			if(nums[mid] == target)
				return mid;

			// if left part is sorted and number lies in between
			if (nums[mid] >= nums[l])
			{
				if (target >= nums[l] && target < nums[mid])
					r = mid - 1;
				else
					l = mid + 1;
			}
			// right part is sorted
			else
			{
				if (target > nums[mid] && target <= nums[r])
					l = mid + 1;
				else
					r = mid - 1;
			}				
		}		
		return -1;
	}
}