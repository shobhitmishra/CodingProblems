<Query Kind="Program" />

void Main()
{
	var ob = new Solution();
	var input = new int[]{1, 2, 3, 4, 5, 6, 7};
	ob.RemoveDuplicates(input).Dump();
}

// Define other methods and classes here
public class Solution 
{
    public int RemoveDuplicates(int[] nums) 
	{
        if(nums == null || nums.Length == 0)
			return 0;
		if(nums.Length == 1)
			return 1;
		int copyPtr = 1;
		for (int i = 1; i < nums.Length; i++)
		{
			if(nums[i] != nums[i-1])
				nums[copyPtr++] = nums[i];
		}
		return copyPtr;
    }
}