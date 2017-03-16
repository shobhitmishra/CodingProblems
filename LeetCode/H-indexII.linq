<Query Kind="Program" />

void Main()
{
	var ob = new Solution();
}

// Define other methods and classes here
public class Solution
{
	public int HIndex(int[] citations)
	{
		int start = 0;
		int end = citations.Length - 1;
		int result = 0;
		while (start <= end)
		{
			int mid = start + (end - start) / 2;
			if (citations[mid] >= citations.Length - mid)
			{
				result = citations.Length - mid;
				end = mid -1;
			}
			else
				start = mid + 1;
		}		
		return result;
	}
}