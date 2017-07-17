<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.IO.dll</Reference>
</Query>

void Main()
{
	var ob = new Solution();
	ob.AddBinary("1101", "111").Dump();
}

// Define other methods and classes here
public class Solution
{
	public string AddBinary(string a, string b)
	{
		var result = "";
		int i = a.Length -1;
		int j = b.Length - 1;
		int carry = 0;
		while (i >= 0 || j >= 0 || carry > 0)
		{
			var first = i >= 0 ? GetNum(a[i]) : 0;
			var second = j >= 0 ? GetNum(b[j]) : 0;
			var sum = first + second + carry;
			carry = sum /2;
			result = (sum%2).ToString() + result;
			i--; j--;
		}
		return result;
	}
	
	private int GetNum(char ch)
	{
		if(ch == '0')
			return 0;
		return 1;
	}
}