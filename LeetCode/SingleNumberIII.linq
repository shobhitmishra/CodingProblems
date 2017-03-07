<Query Kind="Program" />

void Main()
{
	var nums = new int[]{1, 2};
	var ob = new Solution();
	ob.SingleNumber(nums).Dump();
}

// Define other methods and classes here
public class Solution 
{
    public int[] SingleNumber(int[] nums) 
	{
        int aXORb = 0;
		var result = new int[2];
		if(nums.Length < 2)
			return result;
		foreach (int num in nums)
		{
			aXORb ^= num;
		}
		int mask = aXORb &(~(aXORb-1));
		foreach (int num in nums)
		{
			int temp = num & mask;
			if(temp == 0)
				result[0] ^= num;
			else
				result[1] ^= num;
		}
		
		return result;
    }
}