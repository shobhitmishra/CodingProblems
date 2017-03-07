<Query Kind="Program" />

/*
Given a string and a string dictionary, find the longest string in the dictionary 
that can be formed by deleting some characters of the given string. 
If there are more than one possible results, return the longest word with the smallest 
lexicographical order. If there is no possible result, return the empty string.
*/
void Main()
{
	var listOfWords = new List<string>() {"ale", "ble", "apple", 
	"couple", "waffle", "monkey","plea", "flee", "suppl", "amide", "drunk" };
	var ob = new Solution();
	ob.FindLongestWord("abpcplea", listOfWords).Dump();
//	ob.IsSubsequence("apple", "apple").Dump();
//	ob.IsSubsequence("plea", "abpcplea").Dump();
//	ob.IsSubsequence("", "abpcplea").Dump();
}

// Define other methods and classes here
public class Solution 
{
    public string FindLongestWord(string s, IList<string> d) 
	{
     	// First sort the words in dictionary and then group by length
		var sortedWords = d.OrderBy(x => x).GroupBy(x => x.Length);		
		
		// Arrange in the reverse order of key length and then merge the lists
		var words = sortedWords.OrderByDescending(x => x.Key).SelectMany(x => x.ToList());
		foreach (var word in words)
		{
			if(IsSubsequence(word, s))
				return word;
		}
		
		return "";
    }
	
	// Returns true if str1 is a subsequnce of str2. Else returns false
	public bool IsSubsequence(string str1, string str2)
	{
		if(str1.Length > str2.Length)
			return false;
		
		int str2Ptr = 0;
		int str1Ptr = 0;
		while(str1Ptr < str1.Length && str2Ptr < str2.Length)
		{
			if(str1[str1Ptr] == str2[str2Ptr])
			{
				str1Ptr++;
				str2Ptr++;
			}
			else
				str2Ptr++;
		}
		return str1Ptr == str1.Length;
	}
}