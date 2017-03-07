<Query Kind="Program" />

void Main()
{
	var ob = new Solution();
	var haystack = "hazyhayhay";
	var needle = "hay";
	ob.StrStr(haystack, needle).Dump();
}

// Define other methods and classes here
public class Solution 
{
    public int StrStr(string haystack, string needle) 
	{		
        if(needle.Length > haystack.Length)
			return -1;
		if(haystack == needle)
			return 0;
		
		for (int i = 0; i <= haystack.Length - needle.Length; i++)
		{
			string subStr = haystack.Substring(i, needle.Length);
			if(subStr == needle)
				return i;
		}
		return -1;
    }
}