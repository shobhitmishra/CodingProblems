<Query Kind="Program" />

void Main()
{
	var input = "]";
	var ob = new Solution();
	ob.IsValid(input).Dump();
}

// Define other methods and classes here
public class Solution {
    public bool IsValid(string s) 
	{
    	var stack = new Stack<char>();
		foreach (char c in s)
		{
			if(c == '(' || c == '{' || c== '[')
				stack.Push(c);				
			else 
			{
				if(stack.Count() == 0)
					return false;
				var stackChar = stack.Pop();				
				if(c == ')' && stackChar != '(')
					return false;
				if(c == '}' && stackChar != '{')
					return false;
				if(c == ']' && stackChar != '[')
					return false;
			}
		}
		return stack.Count() == 0;
    }
}