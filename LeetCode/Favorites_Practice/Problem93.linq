<Query Kind="Program" />

void Main()
{
	var ob = new Solution();
	var input = "25525511135";
	ob.RestoreIpAddresses(input).Dump();
}

// Define other methods and classes here
public class Solution
{
	public IList<string> RestoreIpAddresses(string s)
	{
		var result = new List<string>();
		RestoreIpAddressHelper(s.Trim(), 1, "", result);
		return result;
	}
	
	private void RestoreIpAddressHelper(string s, int quartNo, string stringSoFar, List<string> result)
	{
		if (quartNo == 5)
		{
			if(string.IsNullOrEmpty(s))
				result.Add(stringSoFar);
			return;
		}
		// string is longer than permissible length
		if(s.Length > (5 - quartNo) * 3)
			return;
			
		for (int i = 1; i <= s.Length && i <= 3; i++)
		{
			var quartet = s.Substring(0, i);
			if (IsValidQuartet(quartet))
			{
				var copyStr = stringSoFar;
				if(string.IsNullOrEmpty(stringSoFar) == false)
					copyStr += ".";
				copyStr += quartet;
				var remainingStr = s.Substring(i, s.Length - i);
				RestoreIpAddressHelper(remainingStr, quartNo + 1, copyStr, result);
			}
		}
	}
	
	private bool IsValidQuartet(string s)
	{
		if(string.IsNullOrEmpty(s))
			return false;
		// convert it to a number and that should fall between 0 and 255
		var num = Int32.Parse(s);
		if(num == 0 && s.Length > 1)
			return false;
		if(num > 255)
			return false;
		if(num > 0 && s[0] == '0')
			return false;
		return true;
	}
}