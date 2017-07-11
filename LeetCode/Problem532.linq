<Query Kind="Program" />

void Main()
{
	var input = new int[] { 1,1,2,2,3,3,4,4,5};
	var ob = new Solution();
	ob.FindPairs(input,0).Dump();
}

// Define other methods and classes here
public class Solution
{
	public int FindPairs(int[] nums, int k)
	{
		if( k < 0)
			return 0;
		Array.Sort(nums);
		var dict = nums.GroupBy(x => x).ToDictionary(y => y.Key, y => y.Count());		
		var result = 0;
		for (int i = 0; i < nums.Length; i++)
		{
			if(i > 0 && nums[i] == nums[i-1])
				continue;
			if (k == 0)			
				result += dict[nums[i]] > 1 ? 1 : 0;			
			else
				result += dict.ContainsKey(nums[i] + k) ? 1 : 0; 
		}
		return result;
	}
}