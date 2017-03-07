<Query Kind="Program" />

void Main()
{
	var ob = new Solution();
	var input = new int[]{17};
	ob.Rob(input).Dump();
}

// Define other methods and classes here
public class Solution 
{
	public int Rob(int[] nums) 
	{
		if(nums == null || nums.Length == 0)
			return 0;
		if(nums.Length == 1)
			return nums[0];
		int size = nums.Length -1;
  		int[] FirstExcluded = nums.Skip(1).Take(size).ToArray();
		int[] LastExcluded = nums.Take(size).ToArray();
		return Math.Max(RobHelper(FirstExcluded), RobHelper(LastExcluded));
    }
	
    public int RobHelper(int[] nums) 
	{    	
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