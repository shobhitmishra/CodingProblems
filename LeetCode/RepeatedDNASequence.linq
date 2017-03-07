<Query Kind="Program" />

void Main()
{
	var ob = new Solution();
	ob.FindRepeatedDnaSequences("AAAAACCCCCAAAAACCCCCCAAAAAGGGTTT").Dump();
}

// Define other methods and classes here
public class Solution 
{
    public IList<string> FindRepeatedDnaSequences(string s) 
	{
    	var subStrHash = new HashSet<string>();
		var result = new HashSet<string>();
		if(s.Length <= 10)
			return result.ToList();
		for (int i = 0; i <= s.Length -10; i++)
		{
			var sequence = s.Substring(i,10);
			if(subStrHash.Contains(sequence))
				result.Add(sequence);
			subStrHash.Add(sequence);
		}
		return result.ToList();
    }
}