<Query Kind="Program" />

void Main()
{
	var str1 = "paper";
	var str2 = "title";
	var ob = new Solution();
	ob.IsIsomorphic(str1, str2).Dump();
}

// Define other methods and classes here
public class Solution 
{
    public bool IsIsomorphic(string s, string t) 
	{        
		if(s.Length != t.Length)
			return false;
    	var charReplaceDict = new Dictionary<char, char>();	
		var replacedCharSofar = new HashSet<char>();
		for (int i = 0; i < s.Length; i++)
		{
			if(!charReplaceDict.ContainsKey(s[i]))
			{
				if(replacedCharSofar.Contains(t[i]))
					return false;
				charReplaceDict.Add(s[i],t[i]);
				replacedCharSofar.Add(t[i]);
			}
			else
			{
				if(charReplaceDict[s[i]] != t[i])
					return false;
			}
		}
		return true;
	}	
}
