<Query Kind="Program" />

void Main()
{
	var input = new int[] { 6, 5, 4, 3, 8, 2, 12, 16};
	var ob = new Solution();
	ob.LargestDivisibleSubset(input).Dump();
}

// Define other methods and classes here
public class Solution
{
	public IList<int> LargestDivisibleSubset(int[] nums)
	{
		if(nums.Length == 0)
			return new List<int>();
		var result = new List<int>[nums.Length];
		Array.Sort(nums);
		for (int i = 0; i < nums.Length; i++)
		{
			result[i] = new List<int>() { nums[i]};
		}
		int maxSize = 1;
		int maxSizeIndex = 0;
		for (int i = 0; i < nums.Length; i++)
		{
			for (int j = 0; j < i; j++)
			{
				if (nums[i] % nums[j] == 0)
				{
					if (result[j].Count + 1 > result[i].Count)
					{
						result[i] = new List<int>(result[j]);
						result[i].Add(nums[i]);
					}
				}
			}
			if (result[i].Count > maxSize)
			{
				maxSize = result[i].Count;
				maxSizeIndex = i;
			}
		}
		return result[maxSizeIndex];
	}
}