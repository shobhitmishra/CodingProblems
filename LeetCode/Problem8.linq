<Query Kind="Program" />

void Main()
{
	var input = "   +123asdfdsf";
	var ob = new Solution();
	ob.MyAtoi(input).Dump();
}

// Define other methods and classes here
public class Solution
{	
	public int MyAtoi(string str)
	{
		str = str.Trim();
		if(string.IsNullOrWhiteSpace(str))
			return 0;
		int sign = 1;
		int ptr = 0;
		if (str[ptr] == '+' || str[ptr] == '-')
		{
			sign *= str[ptr] == '-' ? -1 : 1;
			ptr++;
		}

		long result = 0;
		while (ptr < str.Length)
		{
			if (str[ptr] < '0' || str[ptr] > '9')
			{				
				break;
			}
			int num = str[ptr] - '0';
			result = result * 10 + num;		
			if(result >= Int32.MaxValue)
				break;
			ptr++;
		}
		result *= sign;
		if(result > Int32.MaxValue)
			return Int32.MaxValue;
		if(result < Int32.MinValue)
			return Int32.MinValue;
		return (int)result;
	}
}