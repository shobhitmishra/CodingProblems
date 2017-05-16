<Query Kind="Program" />

void Main()
{
	var input = "PAYPALISHIRING";
	var ob = new Solution();
	ob.Convert(input,3).Dump();
}

// Define other methods and classes here
public class Solution
{	
	public string Convert(string s, int numRows)
	{
		if(numRows == 1)
			return s;
		var result = new List<char>[numRows];
		for (int i = 0; i < numRows; i++)
		{
			result[i] = new List<char>();
		}
		var direction = 1;
		var currentRow = 0;
		foreach (char ch in s)
		{
			result[currentRow].Add(ch);
			currentRow = currentRow + direction;
			if(currentRow == 0 || currentRow == numRows -1)
				direction *= -1;
		}
		var resultStr = "";
		for (int i = 0; i < numRows; i++)
		{
			var str = string.Join("", result[i]);
			resultStr += str;
		}
		return resultStr;
	}
}