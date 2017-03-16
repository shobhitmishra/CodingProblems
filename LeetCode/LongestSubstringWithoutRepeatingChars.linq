<Query Kind="Program" />

void Main()
{
	var str = "pwwkew";
	var ob = new Solution();
	ob.LengthOfLongestSubstring(str).Dump();
}

// Define other methods and classes here
public class Solution
{
	public int LengthOfLongestSubstring(string s)
	{
		var positionDic = new Dictionary<char,int>();
		var longestLength = 0;
		int start = 0;
		for (int i = 0; i < s.Length; i++)
		{
			var currentChar = s[i];
			// if we have not seen this char before
			if (!positionDic.ContainsKey(currentChar))			
				positionDic.Add(currentChar, i);				
			
			else
			{
				if(positionDic[currentChar] >= start)
					start = positionDic[currentChar] + 1;
				positionDic[currentChar] = i;
			}
			longestLength = Math.Max(longestLength, i - start + 1);
		}
		
		return longestLength;
	}
}