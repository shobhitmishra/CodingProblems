<Query Kind="Program" />

void Main()
{
	var input = new int[] {1};
	var ob = new Solution();
	ob.FirstMissingPositive(input).Dump();
}

// Define other methods and classes here
public class Solution
{
	public int FirstMissingPositive(int[] nums)
	{
		if(nums.Length == 0)
			return 1;
		
		var size = nums.Length;		
		bool hasLastElementSeen = false;
		
		for (int i = 0; i < size; i++)
		{
			if(nums[i] == size)
				hasLastElementSeen = true;
			if (nums[i] < 0 || nums[i] >= size)
				nums[i] = 0;
		}
		
		for (int i = 0; i < size; i++)
		{
			var originalNum = nums[i] % size;
			if (nums[originalNum] < size)
				nums[originalNum] += size;
		}

		for (int i = 1; i < size; i++)
		{
			if (nums[i] < size)
				return i;
		}

		return hasLastElementSeen ? size + 1 : size;
	}
}