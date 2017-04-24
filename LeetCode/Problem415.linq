<Query Kind="Program" />

void Main()
{
	var ob = new Solution();
	var input1 = "";
	var input2 = "12345";
	ob.AddStrings(input1, input2).Dump();
}

// Define other methods and classes here
public class Solution
{
	public string AddStrings(string num1, string num2)
	{
		string result = "";
		int carry = 0;
		for (int i = num1.Length -1, j = num2.Length -1; i >= 0 || j >= 0 || carry > 0 ; i--, j--)
		{
			int x = i < 0 ? 0 : num1[i] - '0';
			int y = j < 0 ? 0 : num2[j] - '0';
			int sum = x + y + carry;
			result = (sum % 10).ToString() + result;
			carry = sum / 10;
		}
		return result;
	}	
}