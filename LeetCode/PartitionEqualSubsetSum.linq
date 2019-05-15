<Query Kind="Program" />

void Main()
{
	var ob = new Solution();
	var nums = new int[] {35,69,8,10,56,85,20,67,39,15,57,19,80,45,12,81,92,98,25,26,51,3,31,16,30,37,55,52,61,17,30,82,52,85,84,83,98,29,79,29,99,70,97,20,42,22,44,44,65,75,70,86,97,100,45,69,91,53,88,96,65,88,92,73,16,57,34,11,64,3,92,48,98,29,39,16,47,92,22,19,50,86,78,68,52,51,70,80,2,58,79,70,91,94,23,47,81,4,18,15};
	ob.CanPartition(nums).Dump();
}

// Define other methods and classes here
public class Solution
{
	public bool CanPartition(int[] nums)
	{
		long totalSum = nums.Sum();
		if(totalSum %2 != 0)
			return false;
		
		return CanPartitionBottomUp(nums, totalSum/2);
//		var memDict = new bool?[nums.Length + 1, totalSum/2 +1];
//		return CanPartitionRecur(nums, 0, totalSum/2, memDict);
	}
	
	private bool CanPartitionBottomUp(int[] nums, long requiredSum)
	{
		var dp = new bool[nums.Length + 1, requiredSum + 1];
		for (int i = 0; i <= nums.Length; i++)
		{
			dp[i,0] = true;	
		}
		
		for (int i = 1; i <= nums.Length; i++)
		{
			for(int j = 1; j <= requiredSum; j++)
			{
				dp[i,j] = dp[i-1,j] || (j >= nums[i-1] ? dp[i-1, j - nums[i-1]] : false);					
			}
		}
		// PrintSubSet(dp, nums, requiredSum);
		return dp[nums.Length, requiredSum];
	}
	
	private void PrintSubSet(bool[,] dp, int[] nums, long requiredSum)
	{
		if(dp[nums.Length, requiredSum] == false)
			return;
		
		var j = requiredSum;
		for (int i = nums.Length; i >= 0 ; i--)
		{
			if(requiredSum == 0)
				break;
			//keep going up
			if(dp[i,j] == dp[i-1, j])
				continue;
			Console.Write("{0} \t",nums[i-1]);
			requiredSum -= nums[i-1];
			j = requiredSum;
		}
	}
	
	private bool CanPartitionRecur(int[] nums, int currIndex, long requiredSum, bool?[,] memDict)
	{
		if(requiredSum == 0)
			return true;
		if(currIndex >= nums.Length)
			return false;		
		
		if(memDict[currIndex,requiredSum].HasValue)
			return memDict[currIndex,requiredSum].Value;

		var canPartitionWithout = CanPartitionRecur(nums, currIndex + 1, requiredSum, memDict);
		if (canPartitionWithout)
		{
			memDict[currIndex,requiredSum] = true;
			return true;
		}
		
		var canPartitionWith = nums[currIndex] <= requiredSum 
			? CanPartitionRecur(nums, currIndex + 1, requiredSum - nums[currIndex], memDict) : false;		
		memDict[currIndex,requiredSum] = canPartitionWith;
		
		return memDict[currIndex,requiredSum].Value;	
	}
}