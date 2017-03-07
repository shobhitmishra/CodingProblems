<Query Kind="Program" />

void Main()
{
	var input = ")))";
	var ob = new Solution();
	ob.LongestValidParentheses(input).Dump();
}

// Define other methods and classes here
public class Solution 
{
    public int LongestValidParentheses(string s) 
	{
		int maxLengthOfValidParantheses = 0;
       	var stack = new Stack<int>();
		stack.Push(-1);
		for (int i = 0; i < s.Length; i++)
		{
			var currentChar = s[i];
			if(currentChar == '(')
				stack.Push(i);
			else
			{
				if(stack.Count() == 0)
					stack.Push(i);
				else
				{
					stack.Pop();
					if(stack.Count() == 0)
						stack.Push(i);
					else
					{
						var currentLength = i - stack.Peek();
						maxLengthOfValidParantheses = Math.Max(maxLengthOfValidParantheses, currentLength);
					}
				}
			}
		}
		return maxLengthOfValidParantheses;
    }
}