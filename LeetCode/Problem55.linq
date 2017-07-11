<Query Kind="Program" />

void Main()
{
	var input = new int[] { 3,2,1,0,4};
	var ob = new Solution();
	ob.CanJump(input).Dump();
}

// Define other methods and classes here
public class Solution
{
	public bool CanJump(int[] nums)
	{
		int reachable = 0;
    	for (int i=0; i<nums.Length; ++i) 
		{
        	if (i > reachable) return false;
        	reachable = Math.Max(reachable, i + nums[i]);
    	}
    	return true;
	}
}