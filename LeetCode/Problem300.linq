<Query Kind="Program" />

void Main()
{
	var ob = new Solution();
	//var input = new int[] {0,8,4,12,2,10,6,14,1,9,5,13,3,11,7,15};
	var input = new int[] { };
	ob.LengthOfLIS(input).Dump();
}

// Define other methods and classes here
public class Solution
{
	public int LengthOfLIS(int[] nums)
	{
		var len = LengthOfLIS_nSqaure(nums);
		return len;
	}
	
	private int LengthOfLIS_nSqaure(int[] nums)
	{
		int maxLength = 0;
		var lenOfLISEndingHere = Enumerable.Repeat(1, nums.Length).ToArray();
		for (int i = 0; i < nums.Length; i++)
		{			
			for (int j = i - 1; j >= 0; j--)
			{
				if (nums[i] > nums[j])
				{
					var localMax = lenOfLISEndingHere[j] + 1;
					lenOfLISEndingHere[i] = Math.Max(localMax, lenOfLISEndingHere[i]);					
				}
			}
			maxLength = Math.Max(maxLength, lenOfLISEndingHere[i]);
		}
		return maxLength;
	}
}