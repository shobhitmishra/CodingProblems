<Query Kind="Program" />

void Main()
{
	var input = new int[] { 1, 1, 1, 1, 2, 2, 2, 2, 2, 3, 4 };
	var ob = new Solution();
	ob.RemoveDuplicates(input).Dump();
	input.Dump();
}

// Define other methods and classes here
public class Solution
{
	public int RemoveDuplicates(int[] nums)
	{
		if (nums.Length == 0)
			return 0;
		int ptrToReplace = 1;
		var elementCount = 1;
		for (int i = 1; i < nums.Length; i++)
		{
			if (nums[i] == nums[i - 1])
			{
				if(elementCount >= 2)
					continue;
				elementCount++;					
			}
			else
				elementCount = 1;
			nums[ptrToReplace++] = nums[i];
		}
		return ptrToReplace;
	}
}