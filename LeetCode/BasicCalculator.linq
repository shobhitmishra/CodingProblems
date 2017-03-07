<Query Kind="Program" />

void Main()
{
	var input = "  ";
	var ob = new Solution();
	ob.Calculate(input).Dump();
}

// Define other methods and classes here
public class Solution 
{
    public int Calculate(string s) 
	{
		// First do some data massaging		
		s = s.Replace(" ", string.Empty);
		var tokenString = TokenizeString(s);
        var postFix = GetPostfixFromInFix(tokenString);
		return CalculatePostFix(postFix);
    }
	
	public int CalculatePostFix(IEnumerable<string> postFix)
	{
		var output = new Stack<int>();
		foreach (var str in postFix)
		{
			var type = GetTokenType(str);
			if(type == TokenType.Operand)
			{
				var num = Int32.Parse(str);
				output.Push(num);
			}
			else
			{
				var operand2 = output.Pop();
				var operand1 = output.Pop();
				int result = 0;
				
				if(str == "+")
					result = operand1 + operand2;
				else if(str == "-")
					result = operand1 - operand2;
				else if(str == "*")
					result = operand1 * operand2;
				else if(str == "/")
					result = operand1 / operand2;
				
				output.Push(result);
			}
		}
		return output.Pop();
	}
	
	public IEnumerable<string> GetPostfixFromInFix(IEnumerable<string> s)
	{
		var operatorStack = new Stack<string>();
		var outputList = new List<string>();
		foreach (string c in s)
		{
			var type = GetTokenType(c);
			switch(type)
			{
				case TokenType.Operand:
					outputList.Add(c);
					break;
				case TokenType.Operator:
					while(operatorStack.Count > 0 && IsHigherInPrecedence(operatorStack.Peek(), c))
					{
						outputList.Add(operatorStack.Pop());
					}
					operatorStack.Push(c);
					break;
				case TokenType.LeftParantheses:
					operatorStack.Push(c);
					break;
				case TokenType.RightParantheses:
					string current =  string.Empty;
					while(current != "(")
					{
						current = operatorStack.Pop();
						if(current != "(")
							outputList.Add(current);
					}
					break;
				default:
					break;
			}
		}
		while(operatorStack.Count > 0)
		{
			outputList.Add(operatorStack.Pop());
		}
		return outputList;
	}
	
	private IEnumerable<string> TokenizeString(string s)
	{
		List<string> result = new List<string>();
		string token = string.Empty;
		foreach (char c in s)
		{
			var type = GetTokenType(c.ToString());
			if(type == TokenType.Operand)
				token += c.ToString();
			else
			{
				if(!string.IsNullOrEmpty(token))
					result.Add(token);
				result.Add(c.ToString());
				token = string.Empty;
			}
		}
		if(!string.IsNullOrEmpty(token))
			result.Add(token);
		return result;
	}
	
	private bool IsHigherInPrecedence(string operator1, string opertor2)
	{
		return GetOperatorPrcedenceValue(operator1) >= GetOperatorPrcedenceValue(opertor2);
	}
	
	private int GetOperatorPrcedenceValue(string c)
	{
		if(c == "(" || c == ")")
			return 0;
		if(c == "+" || c == "-")
			return 1;
		if(c == "*" || c == "/")
			return 2;
		return Int32.MinValue;
	}
	
	private TokenType GetTokenType(string c)
	{	
		
		if(c == "+" || c == "-" || c == "*" || c == "/")
			return TokenType.Operator;
		if(c == "(")
			return TokenType.LeftParantheses;
		if(c == ")")
			return TokenType.RightParantheses;
		return TokenType.Operand;
	}
	
	private enum TokenType 
	{
		Operand,
		Operator,
		LeftParantheses,
		RightParantheses,
		None
	}
}