<Query Kind="Program" />

void Main()
{
	var input = new int[] {1, 1, 1, 1, 2, 2, 2, 2};
	var ob = new Solution();
	ob.MajorityElement(input).Dump();
}

// Define other methods and classes here
public class Solution
{
	public int MajorityElement(int[] nums)
	{
		int count = 1;
		int majority = nums[0];
		for (int i = 1; i < nums.Length; i++)
		{
			int element = nums[i];
			if (count == 0)
			{
				count++;
				majority = element;
			}
			else count += (nums[i] == majority) ? 1 : -1;
		}		
		return majority;
	}
}