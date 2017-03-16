<Query Kind="Program" />

void Main()
{
	var ob = new Solution();
	var str = "AB";
	ob.Convert(str,2).Dump();
}

// Define other methods and classes here
public class Solution
{
	public string Convert(string s, int numRows)
	{	
		var result = string.Empty;
		var listArr = new List<char>[numRows];
		for (int i = 0; i < numRows; i++)
		{
			listArr[i] = new List<char>();
		}
		
		int direction = -1;
		int currentRow = 0;
		for (int i = 0; i < s.Length; i++)
		{
			listArr[currentRow].Add(s[i]);
			if (numRows > 1)
			{
				if (currentRow == 0 || currentRow == numRows - 1)
					direction *= -1;
				currentRow += direction;
			}						
		}
		
		for (int i = 0; i < numRows; i++)
		{
			result += string.Join("", listArr[i]);
		}
		return result;
	}
}