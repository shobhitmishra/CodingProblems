<Query Kind="Program" />

void Main()
{
	var input = new int[] {0};
	var ob = new Solution();
	ob.FindMissingRanges(input, 0, 4).Dump();
}

// Define other methods and classes here
public class Solution {
    public IList<string> FindMissingRanges(int[] nums, int lower, int upper) 
	{
        var result = new List<string>();
		if(nums == null || nums.Length == 0)
		{
			result.Add(GetRangeString(lower,upper));
			return result;
		}
		
		if(nums[0] != lower)
			result.Add(GetRangeString(lower, nums[0] -1));
		
		for (int i = 1; i < nums.Length; i++)
		{
			if(nums[i] - nums[i-1] > 1)
				result.Add(GetRangeString(nums[i-1] + 1, nums[i] -1));
		}
		
		int len = nums.Length -1;
		if(nums[len] != upper)
			result.Add(GetRangeString(nums[len] + 1, upper));
		
		return result;
    }
	
	private string GetRangeString(int start, int end)
	{
		if(start == end)
			return start.ToString();
		return start + "->" +end;
	}
}