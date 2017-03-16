<Query Kind="Program" />

void Main()
{
	var ob = new Solution();
	var input = "5000111111";
	ob.NumDecodings(input).Dump();
}

// Define other methods and classes here
public class Solution
{
	public int NumDecodings(string s)
	{		
		if(string.IsNullOrEmpty(s) || s[0] == '0')
			return 0;		
		if(s.Length == 1)
			return 1;
		int result = 0;
		int prevPrev = 1;
		int prev = s[0] != '0' ? 1 : 0;	
		
		for (int i = 1; i < s.Length; i++)
		{
			result = 0;
			int first = Convert.ToInt32(s[i].ToString());
			var second = Convert.ToInt32(s.Substring(i -1, 2));
			if(first >= 1 && first <= 9)
				result += prev;
			if(second >= 10 && second <= 26)
				result += prevPrev;	
			prevPrev = prev;
			prev = result;			
		}		
		return result;
	}
}