<Query Kind="Program" />

void Main()
{
	var s = "abcdecdeace";
	var t = "ace";
	var ob = new Solution();
	ob.NumDistinct(s,s).Dump();
}

// Define other methods and classes here
public class Solution
{
	public int NumDistinct(string s, string t)
	{
		if(t.Length > s.Length)
			return 0;
		var old = new int[s.Length + 1];
		for (int i = 1; i <= s.Length; i++)
		{
			if(t[0] == s[i-1])
				old[i] = old[i-1] + 1;
			else
				old[i] = old[i-1];
		}
		
		for (int i = 1; i < t.Length; i++)
		{
			var curr = new int[s.Length + 1];
			for (int j = 1; j <= s.Length; j++)
			{
				if (t[i] == s[j - 1])				
					curr[j] = curr[j-1] + old[j-1];				
				else
					curr[j] = curr[j-1];
			}
			old = curr;
		}		
		return old[s.Length];
	}
}