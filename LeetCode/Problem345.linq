<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.IO.dll</Reference>
</Query>

void Main()
{
	var ob = new Solution();
	ob.ReverseVowels("leetcode").Dump();
}

// Define other methods and classes here
public class Solution
{
	HashSet<char> vowelSet = new HashSet<char>() 
		{'a', 'e', 'i', 'o', 'u', 'A', 'E', 'I', 'O', 'U'};
	public string ReverseVowels(string s)
	{
		int start = 0;
		int end = s.Length - 1;
		var arr = s.ToCharArray();
		while (start < end)
		{
			if (!IsVowel(arr[start]))			
				start++;			
			else if(!IsVowel(arr[end]))
				end--;
			else
			{
				var temp = arr[start];
				arr[start] = arr[end];
				arr[end] = temp;
				start++; end--;
			}
		}
		return new string(arr);
	}
	
	private bool IsVowel(char ch)
	{
		return vowelSet.Contains(ch);
	}
}