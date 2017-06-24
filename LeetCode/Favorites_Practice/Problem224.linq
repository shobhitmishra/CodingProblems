<Query Kind="Program" />

void Main()
{
	
}

// Define other methods and classes here
public class Solution
{
	public int Calculate(string s)
	{
		var postFix = GetPostfixFromInfix(s);
	}
	
	private string GetPostfixFromInfix(string s)
	{
		var result = "";
		var stack = new Stack<char>();
		foreach (char c in s)
		{
			// if space continue
			if (c == ' ')
				continue;
			var type = GetTokenType(c);
			switch (type)
			{
				
			}
		}
	}
}