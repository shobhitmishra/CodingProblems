<Query Kind="Program" />

void Main()
{
	var ob = new Solution();
	ob.NumDecodings("12120").Dump();
}

// Define other methods and classes here
public class Solution
{
	public int NumDecodings(string s)
	{
		int prev = 1;
		int current = 1;
		if(s.Length == 0 || s[0] == '0')
			return 0;
		for (int i = 1; i < s.Length; i++)
		{			
			string str = s[i-1].ToString() + s[i].ToString();
			var num = Int32.Parse(str);
			if(s[i] == '0' && (num == 0 || num > 26))
				return 0;
			int next = current;
			if (num > 10 && num <= 26)
			{
				if((i < s.Length -1 && s[i + 1] == '0') == false)
					next = prev + current;
			}
			prev= current;
			current = next;
		}
		return current;
	}
}