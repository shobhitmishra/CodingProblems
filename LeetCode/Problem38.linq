<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.IO.dll</Reference>
</Query>

void Main()
{
	var ob = new Solution();
	for (int i = 1; i <= 10; i++)
	{
		ob.CountAndSay(i).Dump();
	}
}

// Define other methods and classes here
public class Solution
{
	public string CountAndSay(int n)
	{
		if(n == 1)
			return "1";
		var result = "11";
		for (int i = 3; i <= n; i++)
		{
			var temp = "";
			var count = 1;
			for (int j = 1; j < result.Length; j++)
			{
				if(result[j] == result[j-1])
					count++;
				else
				{
					temp += count.ToString() + result[j-1];
					count = 1;
				}
			}
			temp += count.ToString() + result[result.Length -1];
			result = temp;
		}
		return result;
	}
}