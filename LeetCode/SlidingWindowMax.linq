<Query Kind="Program" />

void Main()
{
	int[] nums = {1};
	var ob = new Solution();
	ob.MaxSlidingWindow(nums,1).Dump();
}

// Define other methods and classes here
public class Solution
{
	public int[] MaxSlidingWindow(int[] nums, int k)
	{
		if (nums == null || nums.Length == 0)
			return new int[] {};
		Queue<int> slidingQueue = new Queue<int>(nums.Take(k));
		List<int> maxSliding = new List<int>();
		maxSliding.Add(slidingQueue.Max());
		for (int i = k; i < nums.Length; i++)
		{	
			slidingQueue.Dequeue();	
			slidingQueue.Enqueue(nums[i]);	
			maxSliding.Add(slidingQueue.Max());							
		}
		return maxSliding.ToArray();
	}
}