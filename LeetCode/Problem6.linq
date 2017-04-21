<Query Kind="Program" />

void Main()
{
	var ob = new Solution();
	var str = "PAYPALISHIRING";
	ob.Convert(str,4).Dump();
}

// Define other methods and classes here
public class Solution
{
	public string Convert(string s, int numRows)
	{
		if(numRows <= 1)
			return s;
		var l = new List<List<char>>();
		for (int i = 0; i < numRows; i++)
		{
			l.Add(new List<char>());
		}
		var current = 0;
		int direction = 1;
		
		foreach (char element in s)
		{
			l[current].Add(element);
			current += direction;
			if(current % (numRows -1) == 0)
				direction *= -1;
		}
		var result = "";
		for (int i = 0; i < numRows; i++)
		{
			var rowResult = string.Join("", l[i]);
			result += rowResult;
		}
		return result;
	}
}