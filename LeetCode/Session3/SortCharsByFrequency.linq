<Query Kind="Program">
  <Namespace>static System.Linq.Enumerable</Namespace>
  <Namespace>System.IO</Namespace>
  <Namespace>System.Collections.Generic</Namespace>
</Query>

void Main()
{
	var input = "eetrttsssfgs";
	var ob = new Solution();
	ob.FrequencySort(input).Dump();
}

// Define other methods and classes here
public class Solution
{
	public string FrequencySort(string s)
	{
		var charFreq = s.GroupBy(ch => ch,
			(ch, list) => new
			{
				Key = ch,
				Count = list.Count(),
				items = list
			}).OrderByDescending(y => y.Count).SelectMany(z => z.items);
		
		return string.Join("",charFreq);
	}
}