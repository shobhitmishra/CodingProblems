<Query Kind="Program" />

void Main()
{
	var ob = new Solution();
	var input = new int[] { 3, 2, 3};
	ob.MajorityElement(input).Dump();
}

// Define other methods and classes here
public class Solution
{
	public int MajorityElement(int[] nums)
	{
		var majorityElement = nums[0];
		int countOfMajorityElement = 1;
		for (int i = 1; i < nums.Length; i++)
		{
			if(nums[i] == majorityElement)
				countOfMajorityElement++;
			else
				countOfMajorityElement--;
			if (countOfMajorityElement == 0)
			{
				majorityElement = nums[i];
				countOfMajorityElement = 1;
			}
		}
		return majorityElement;
	}
}