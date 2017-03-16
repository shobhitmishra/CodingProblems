<Query Kind="Program" />

void Main()
{
	var str = "        a  ";
	var tokenList = Tokenize(str);
	foreach (var token in tokenList)
	{
		str.Substring(token.start, token.end - token.start + 1).Dump();
	}
}

// Define other methods and classes here
public class Token
{
	public int start;
	public int end;
	public int GetLength()
	{
		return end - start + 1;
	}
	public Token(int s, int e)
	{
		start = s;
		end = e;
	}	
}

public List<Token> Tokenize(string s)
{
	var result = new List<Token>();
	int startToken = 0;	
	int endToken = 0;
	for (int i = 0; i < s.Length; i++)
	{
		// if we encounter a space then it means a token has just ended				
		if(s[i] == ' ')
		{
			endToken = i;
			if (s[startToken] != ' ')
			{
				result.Add(new Token(startToken, endToken -1));				
			}
			startToken = i;
		}
		// A non space char means wither the token has started or the last one continued.
		else
		{
			if(i == 0 || (i > 0 && s[i-1] == ' '))
				startToken = i;
		}
	}
	// Add the last token
	if (s[startToken] != ' ')
	{
		result.Add(new Token(startToken, s.Length -1));
	}

	return result;
}