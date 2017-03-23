<Query Kind="Program" />

void Main()
{
	var ob = new Solution();
	var nums = new int[] {4,0,-4,-2,2,5,2,0,-8,-8,-8,-8,-1,7,4,5,5,-4,6,6,-3};
	ob.LongestConsecutive(nums).Dump();
}

// Define other methods and classes here
public class Solution
{
	public int LongestConsecutive(int[] nums)
	{
		if(nums == null || nums.Length == 0)
			return 0;
		var maxLength = 0;
		var setDictionary = new Dictionary<int,int>();
		foreach (var num in nums)
		{
			if(setDictionary.ContainsKey(num))
				continue;
			else
			{
				// we need to find if there is a set left and/or right to it
				var left = setDictionary.ContainsKey(num -1) ? setDictionary[num - 1] : 0;
				var right = setDictionary.ContainsKey(num + 1) ? setDictionary[num + 1] : 0;
				
				var totalLength = left + right + 1;
				setDictionary.Add(num, totalLength);
				maxLength = Math.Max(maxLength, totalLength);
				
				// update the length of boundary elements
				setDictionary[num - left] = totalLength;
				setDictionary[num + right] = totalLength;
			}
		}
		
		return maxLength;
	}
}