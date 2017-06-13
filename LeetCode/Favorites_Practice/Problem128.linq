<Query Kind="Program" />

void Main()
{
	var input = new int[] { 9, 7, 6, 8, 4, 3, 5, 2, 1, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
	var ob = new Solution();
	ob.LongestConsecutive(input).Dump();
}

// Define other methods and classes here
public class Solution
{
	public int LongestConsecutive(int[] nums)
	{
		var maxLen = 0;
		var setDict = new Dictionary<int, int>();
		foreach (var num in nums)
		{
			if (setDict.ContainsKey(num))
				continue;

			var left = setDict.ContainsKey(num - 1) ? setDict[num - 1] : 0;
			var right = setDict.ContainsKey(num + 1) ? setDict[num + 1] : 0;

			var currLen = left + right + 1;
			maxLen = Math.Max(maxLen, currLen);
			setDict.Add(num, currLen);

			// update boundary elements of left and right sets
			setDict[num - left] = currLen;
			setDict[num + right] = currLen;

		}
		return maxLen;
	}
}