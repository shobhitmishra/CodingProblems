<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.IO.dll</Reference>
</Query>

void Main()
{
	var ob = new Solution();
	var v1 = "1.0";
	var v2 = "1";
	ob.CompareVersion(v1,v2).Dump();
}

// Define other methods and classes here
public class Solution
{
	public int CompareVersion(string version1, string version2)
	{
		var charArr = new Char[] {'.'};
		var str1Arr = version1.Split(charArr);
		var str2Arr = version2.Split(charArr);
		for (int i = 0, j =0; i < str1Arr.Length || j < str2Arr.Length; i++, j++)
		{
			var s1 = i >= str1Arr.Length ? "0" : str1Arr[i];
			var s2 = j >= str2Arr.Length ? "0" : str2Arr[j];
			var s1Num = int.Parse(s1);
			var s2Num = int.Parse(s2);
			if(s1Num > s2Num)
				return 1;
			if(s1Num < s2Num)
				return -1;
		}
		return 0;
	}	
}