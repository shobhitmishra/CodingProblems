<Query Kind="Program" />

void Main()
{
	var ob = new Solution();
	var nums = new int[] {4,2,1};
	ob.CombinationSum4(nums,32).Dump();
}

// Define other methods and classes here
public class Solution
{
	public int CombinationSum4(int[] nums, int target)
	{
		var dp = new Dictionary<int,int>();
		//Array.Sort(nums);
		return CombinationSumHelper(nums, target, dp);
	}	
	private int CombinationSumHelper(int[] nums, int target, Dictionary<int,int> dp)
	{
		if (target == 0)
			return 1;
		if(dp.ContainsKey(target))
			return dp[target];
		var ways = 0;
		foreach (var num in nums)
		{
			if (target >= num)
				ways += CombinationSumHelper(nums, target - num, dp);
		}
		dp.Add(target,ways);
		return ways;
	}
}