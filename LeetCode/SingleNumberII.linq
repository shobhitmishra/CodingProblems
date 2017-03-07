<Query Kind="Program" />

void Main()
{
	var nums = new int[]{-2,-2,1,1,-3,1,-3,-3,-4,-2};
	var ob = new Solution();
	ob.SingleNumber(nums).Dump();
}

// Define other methods and classes here
public class Solution 
{
    public int SingleNumber(int[] nums) 
	{
        var result = "";
		for (int i = 0; i < 32; i++)
		{
			int mask = 1 <<i;
			int count = 0;
			foreach (var num in nums)
			{
				if((num & mask) != 0)
					count++;
			}
			result = count % 3 + result;			
		}
		return Convert.ToInt32(result,2);
    }
}