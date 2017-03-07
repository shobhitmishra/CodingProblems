<Query Kind="Program" />

void Main()
{
	var ob = new Solution();
	var str1 = "";
	var str2 = "aabcc";
	var str3 = "aabcc";
	ob.IsInterleave(str1, str2, str3).Dump();
}

// Define other methods and classes here
public class Solution 
{
    public bool IsInterleave(string s1, string s2, string s3) 
	{
		if(s3.Length != s1.Length + s2.Length)
			return false;		
		
    	var result = new bool[s2.Length + 1, s1.Length + 1];
		result[0,0] = true;
		for (int j = 1; j <= s1.Length; j++)
		{
			result[0,j] = result[0,j-1] && (s1[j-1] == s3[j-1]);
		}
		for (int i = 1; i <= s2.Length; i++)
		{
			result[i,0] = result[i-1,0] && (s2[i-1] == s3[i-1]);
		}
		for (int i = 1; i <= s2.Length; i++)
		{
			for (int j = 1; j <= s1.Length; j++)
			{
				result[i,j] = (result[i,j-1] && (s3[i+j-1] == s1[j-1])) || 
						(result[i-1,j] &&(s3[i+j -1] == s2[i-1]));
			}
		}
		return result[s2.Length, s1.Length];
    }
}