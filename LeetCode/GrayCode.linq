<Query Kind="Program" />

void Main()
{
	var ob = new Solution();
	var gray = ob.GrayCode(0);
	gray.Dump();
}

// Define other methods and classes here
public class Solution
{
	public IList<int> GrayCode(int n)
	{
		if (n == 0)
			return new List<int>() { 0};
		var gray = GrayCodeHelper(n);
		return gray.Select(x => Convert.ToInt32(x, 2)).ToList();
	}
	public List<string> GrayCodeHelper(int n)
	{
		if (n == 1)
			return new List<string>() { "0", "1"};
		var gray = GrayCodeHelper(n -1);
		var reverseGrayCode = Enumerable.Reverse(gray);
		
		var result = gray.Select( x => "0" + x).ToList();
		result.AddRange(reverseGrayCode.Select(x => "1" + x).ToList());
		return result;
	}
}