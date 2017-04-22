<Query Kind="Program" />

void Main()
{
	var input = new int[] {1,2,3};
	var ob = new Solution();
	ob.CheckSubarraySum(input, 5).Dump();
}

// Define other methods and classes here
public class Solution
{
	public bool CheckSubarraySum(int[] nums, int k)
	{
		if (nums.Length <= 1) return false;
		
		// Two continuous "0" will form a subarray which has sum = 0. 0 * k == 0 will always be true. 
		for (int i = 0; i < nums.Length - 1; i++)
		{
			if (nums[i] == 0 && nums[i + 1] == 0) return true;
		}

		// At this point, k can't be "0" any longer.
		if (k == 0) return false;
		
		// Let's only check positive k. Because if there is a n makes n * k = sum, it is always true -n * -k = sum.
		if (k < 0) k = -k;
		
		var runningSum = 0;
		var hasSeenBefore = new Dictionary<int, int>();	
		hasSeenBefore.Add(0, -1);
		
		for (int i = 0; i < nums.Length; i++)
		{
			runningSum = (runningSum + nums[i]) % k;			
			if (hasSeenBefore.ContainsKey(runningSum))
			{
				if (i - hasSeenBefore[runningSum] > 1)
					return true;
			}
			else
				hasSeenBefore.Add(runningSum, i);
		}
		return false;
	}
}