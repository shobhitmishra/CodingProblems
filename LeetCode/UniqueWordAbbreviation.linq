<Query Kind="Program" />

void Main()
{
	var input = new[] { "deer", "door", "cake", "card" };
	var test = new[] {"dear", "cart", "cane", "make"};
	var ob = new ValidWordAbbr(input);
	foreach (var element in test)
	{
		ob.IsUnique(element).Dump();
	}
}

// Define other methods and classes here
public class ValidWordAbbr
{
	Dictionary<string,int> abbFrequency = new Dictionary<string, int>();
	HashSet<string> words;
	
	public ValidWordAbbr(string[] dictionary)
	{
		words = new HashSet<string>(dictionary);
		foreach (var str in words)
		{
			var abb = GetAbbreviation(str);
			if(abbFrequency.ContainsKey(abb))
				abbFrequency[abb]++;
			else
				abbFrequency.Add(abb,1);
		}
	}

	private string GetAbbreviation(string str)
	{
		if(str.Length <= 2)
			return str;
		var abb = str[0].ToString() + (str.Length - 2).ToString() + str[str.Length -1].ToString();
		return abb;
	}

	public bool IsUnique(string word)
	{
		// Get abbreviation
		var abb = GetAbbreviation(word);
		if(!abbFrequency.ContainsKey(abb))
			return true;
		if(abbFrequency[abb] > 1)
			return false;
		else
			return words.Contains(word);
	}
}
