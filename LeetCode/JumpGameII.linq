<Query Kind="Program" />

void Main()
{
	var nums = new int[] {1,2,3,5,4,2,3,2,1,1,1,6};
	var ob = new Solution();
	ob.Jump(nums).Dump();
}

// Define other methods and classes here
public class Solution
{
	public int Jump(int[] nums)
	{
		if(nums.Length <= 1)
			return 0;
		if(nums[0] >= nums.Length) 
			return 1;
		int result = 0;
		int currentPosition = 0;
		while (currentPosition + nums[currentPosition] < nums.Length -1)
		{
			int nextPosition = GetNextPosition(currentPosition, nums);
			currentPosition = nextPosition;
			result++;
		}		
		return result + 1;
	}

	public int GetNextPosition(int currentPosition, int[] nums)
	{
		int limit = Math.Min(currentPosition + nums[currentPosition], nums.Length - 1);		
		int maxReach = currentPosition + nums[currentPosition];
		int nextPosition = currentPosition;
		for (int i = currentPosition + 1; i <= limit; i++)
		{
			if (nums[i] + i > maxReach)
			{
				nextPosition = i;
				maxReach = nums[i] + i;
			}
		}
		return nextPosition;
	}
}