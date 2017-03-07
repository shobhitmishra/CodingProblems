<Query Kind="Program" />

void Main()
{
	var ob = new Solution();
	var input = new int[]{6, 1, 1, 9, 1, 1, 13, 1, 1, 17};
	ob.Rob(input).Dump();
}

// Define other methods and classes here
public class Solution 
{
    public int Rob(int[] nums) 
	{
    	if(nums == null || nums.Length == 0)
			return 0;
		
		int prev = 0;
		int current = nums[0];
		for (int i = 1; i < nums.Length; i++)
		{
			int temp = Math.Max(prev + nums[i], current);
			prev = current;
			current = Math.Max(current, temp);
		}
		return current;
    }
}