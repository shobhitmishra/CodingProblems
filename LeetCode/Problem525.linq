<Query Kind="Program" />

/*
Given a binary array, find the maximum length of a contiguous subarray with equal number of 0 and 1.

Example 1:
Input: [0,1]
Output: 2
Explanation: [0, 1] is the longest contiguous subarray with equal number of 0 and 1.
*/
void Main()
{
	var ob = new Solution();
	var input = new int[] {};
	ob.FindMaxLength(input).Dump();
}

// Define other methods and classes here
public class Solution 
{
    public int FindMaxLength(int[] nums) 
	{
       	int[] zeroCount = new int[nums.Length + 1];
		int[] oneCount = new int[nums.Length + 1];
		for (int i = 1; i <= nums.Length; i++)
		{
			if(nums[i-1] == 0)
			{
				zeroCount[i] = zeroCount[i -1] + 1;
				oneCount[i] = oneCount[i -1];
			}
			else
			{
				oneCount[i] = oneCount[i -1] + 1;
				zeroCount[i] = zeroCount[i -1];
			}
		}
		
		int contiguousLength = 0;
		for (int i = 1; i <= nums.Length; i++)
		{
			for (int j = i + 1; j <= nums.Length; j++)
			{
				int countZeroBetweeniandj = zeroCount[j] - zeroCount[i-1];
				int countOneBetweeniandj = oneCount[j] - oneCount[i-1];
				if(countZeroBetweeniandj == countOneBetweeniandj)
					contiguousLength = Math.Max(contiguousLength, 
					countOneBetweeniandj + countZeroBetweeniandj);
			}
		}
		
		return contiguousLength;
    }
}