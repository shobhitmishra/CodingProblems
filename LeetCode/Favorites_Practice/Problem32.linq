<Query Kind="Program" />

void Main()
{
	var ob = new Solution();
	var s = "()(()";
	//ob.LongestValidParenthesesNSquare(s).Dump();
	ob.LongestValidParenthesesNSquare(s).Dump();
}

// Define other methods and classes here
public class Solution
{
	public int LongestValidParentheses(string s)
	{
		var open = '(';		
		var maxLength = 0;
		var stack = new Stack<int>();
		var invalidCloseIndex = -1;
		for (int i = 0; i < s.Length; i++)
		{
			var ch = s[i];
			if (ch == open)
				stack.Push(i);
			else
			{
				// if invalid closing
				if(stack.Count() == 0)
					invalidCloseIndex = i;
				else
				{
					stack.Pop();
					if(stack.Count == 0)
						maxLength = Math.Max(maxLength, i - invalidCloseIndex);
					else
						maxLength = Math.Max(maxLength, i - stack.Peek());
				}
			}
		}
		
		return maxLength;
	}
	
	public int LongestValidParenthesesNSquare(string s)
	{
		var open = '(';
		var close = ')';
		var dp = new bool[s.Length, s.Length];
		var maxLength = 0;
		for (int diff = 1; diff < s.Length; diff++)
		{
			for (int i = 0; i + diff < s.Length; i++)
			{
				int j = i + diff;
				if (s[i] == open && s[j] == close)
				{
					if(j - i == 1)
						dp[i,j] = true;
					else if(dp[i+1, j-1])
						dp[i, j] = true;
					else
					{
						// if any k exists such that s(i) .. s(k) is valid
						// and s(k + 1) .. s(j) is valid then s(i) .. s(j) is valid
						for (int k = i + 1; k < j; k++)
						{
							if (dp[i, k] && dp[k + 1, j])
							{
								dp[i, j] = true;
								break;
							}
						}
					}
				}
				if(dp[i,j])
					maxLength = Math.Max(maxLength, j - i +1);
			}
		}
		//dp.Dump();
		return maxLength;
	}
}