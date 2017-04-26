<Query Kind="Program" />

void Main()
{
	var ob = new Solution();
	var negativeInput = new int[] { 7, 2,5,10,8 };
	var input = negativeInput;
	ob.SplitArray(input, 2).Dump();
}

// Define other methods and classes here
public class Solution
{

	// This is a real tricky binary search problem. 
	// Look here for explanation:
	// https://discuss.leetcode.com/topic/61324/clear-explanation-8ms-binary-search-java
	public int SplitArray(int[] nums, int m)
	{
		long right = 0;
		long left = 0;
		foreach (var num in nums)
		{
			left = Math.Max(left, num);
			right += num;
		}
		if(m == 1)
			return (int) right;

		while (left <= right)
		{
			long mid = (right + left) / 2;
			if(IsValid(mid, nums, m))
				right = mid - 1;
			else
				left = mid + 1;
		}
		return (int)left;
	}
	
	public bool IsValid(long max, int[] nums, int m)
	{
		int count = 1;
		long cumSum = 0;
		foreach (var num in nums)
		{
			cumSum += num;
			if (cumSum > max)
			{
				cumSum = num;
				count++;
				if(count > m)
					return false;
			}
		}
		
		return true;
	}

}