<Query Kind="Program" />

void Main()
{
	var input = new int[] { 1, 4};
	var duration = 2;
	var ob = new Solution();
	ob.FindPoisonedDuration(input,duration).Dump();
}

// Define other methods and classes here
public class Solution
{
	public int FindPoisonedDuration(int[] timeSeries, int duration)
	{
		if(timeSeries.Length == 0)
			return 0;
		long totalDuration = 0;
		long max = timeSeries[0] + duration;
		long start = timeSeries[0];
		for (int i = 1; i < timeSeries.Length; i++)
		{
			if (timeSeries[i] > max)
			{
				totalDuration += (max - start);
				start = timeSeries[i];
			}
			max = timeSeries[i] + duration;
		}
		totalDuration += (max - start);
		return (int)totalDuration;
	}
}