<Query Kind="Program" />

void Main()
{
	var input = new int[] {};
	var ob = new Solution();
	ob.SummaryRanges(input).Dump();
}

// Define other methods and classes here
public class Solution 
{
    public IList<string> SummaryRanges(int[] nums) 
	{
        var result = new List<string>();
		if(nums == null || nums.Length == 0)
			return result;
		int startRange = nums[0];
		int endRange = nums[0];
		for (int i = 1; i < nums.Length; i++)
		{
			if(nums[i] - nums[i-1] == 1)
				endRange = nums[i];
			else
			{
				var str = GetRangeString(startRange,endRange);
				result.Add(str);
				startRange=endRange=nums[i];
			}
		}
		result.Add(GetRangeString(startRange,endRange));
		return result;
    }
	
	private string GetRangeString(int start, int end)
	{
		if(start == end)
			return start.ToString();
		return start + "->" +end;
	}
}