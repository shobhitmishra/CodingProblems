<Query Kind="Program" />

void Main()
{
	
}

// Define other methods and classes here
public class Solution
{
	public int FindDuplicate(int[] nums)
	{
		int slow = nums[0];
		int fast = nums[nums[0]];
		// Fast and slow will meet somewhere in the cycle
		while (slow != fast)
		{
			slow = nums[slow];
			fast = nums[nums[fast]];
		}
		fast = 0;
		while (slow != fast)
		{
			slow = nums[slow];
			fast = nums[fast];
		}
		return slow;
	}
}