<Query Kind="Program" />

void Main()
{
	var ob = new Solution();
	var citation = new[] {2};
	ob.HIndex(citation).Dump();
}

// Define other methods and classes here
public class Solution
{
	public int HIndex(int[] citations)
	{
		var orderedCitation = citations.OrderByDescending(x => x).ToArray();
		for (int i = 0; i < orderedCitation.Length; i++)
		{
			if(orderedCitation[i] < i + 1)
				return i;
		}
		return citations.Length;
	}
}