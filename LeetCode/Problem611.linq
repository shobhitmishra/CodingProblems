<Query Kind="Program" />

void Main()
{
	var nums = new int[] {30,13,98,59,11,27,7,0,68,98};
	var ob = new Solution();	
	ob.TriangleNumber(nums).Dump();
}

// Define other methods and classes here
public class Solution
{
	public int TriangleNumber(int[] nums)
	{
		var result = 0;
		Array.Sort(nums);
		for (int i = 0; i < nums.Length; i++)
		{
			if(nums[i] == 0)
				continue;
			for (int j = i + 1; j < nums.Length; j++)
			{
				// find the number that is just bigger than i + j
				var sum = nums[i] + nums[j];
				var index = FindIndexOfEqualOrBigger(nums, sum, j);
				var numOfTriangles = 0;
				numOfTriangles = nums[index] >= sum ? index - j - 1 : index - j;
				
				if(numOfTriangles > 0)
					result += numOfTriangles;
			}
		}
		return result;
	}
	
	public int FindIndexOfEqualOrBigger(int[] nums, int target, int start)
	{		
		if(target > nums[nums.Length -1])
			return nums.Length -1;
		if(target < nums[0])
			return 0;
		
		int end = nums.Length - 1;
		while (start <= end)
		{
			int mid = (start + end) / 2;
			if(nums[mid] < target)
				start = mid + 1;
			else
			{
				if(mid == 0 || nums[mid-1] < target)
					return mid;				
				end = mid -1;
			}			
		}
		return end;
	}
}