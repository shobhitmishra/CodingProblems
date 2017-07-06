<Query Kind="Program" />

void Main()
{
	var input = new int[] {0,1,2,4,5,7};
	var ob = new Solution();
	ob.SummaryRanges(input).Dump();
}

// Define other methods and classes here
public class Solution
{
	public IList<string> SummaryRanges(int[] nums)
	{
		var result = new List<string>();
		if(nums.Length == 0)
			return result;
		var startRange = nums[0];
		var endRange = nums[0];
		for (int i = 1; i < nums.Length; i++)
		{
			if(nums[i] == nums[i-1] + 1)
				endRange++;
			else
			{
				result.Add(GetRange(startRange, endRange));
				startRange = endRange = nums[i];
			}
		}
		result.Add(GetRange(startRange, endRange));
		return result;
	}
	private string GetRange(int startRange, int endRange)
	{
		if(startRange == endRange)
			return startRange.ToString();
		return $"{startRange}->{endRange}";
	}
}