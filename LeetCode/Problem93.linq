<Query Kind="Program" />

void Main()
{
	var ob = new Solution();
	var input = "010010";
	ob.RestoreIpAddresses(input).Dump();
}

// Define other methods and classes here
public class Solution
{
	public IList<string> RestoreIpAddresses(string s)
	{
		var result = new List<string>();
		RestoreIpAddressBackTrack(s,4,"", result);
		return result;
	}
	
	private void RestoreIpAddressBackTrack(string s, int numberOfQuartets, 
		string ipsoFar, List<string> result)
	{
		// Can't be a valid ip if it is longer than quartet length
		if(s.Length > numberOfQuartets * 3 || string.IsNullOrWhiteSpace(s))
			return;
		// Base case
		if (numberOfQuartets == 1)
		{
			//convert the last quartet to integer and make sure it is between 0 and 255			
			if (IsValidQuartet(s, numberOfQuartets))
			{
				result.Add(ipsoFar + "."+ s);
				return;
			}		
			return;	
		}
		
		var strThusFar = ipsoFar;
		// Try putting a "." at different positions
		for (int quartetLength = 1; quartetLength <= 3 && quartetLength < s.Length; quartetLength++)
		{
			// choose quartet Lentght upto 3 and if it is valid, call the method recursively
			var quartet = s.Substring(0, quartetLength);
			if (IsValidQuartet(quartet, numberOfQuartets))
			{
				var remaining = s.Substring(quartetLength, s.Length - quartetLength);
				if(!string.IsNullOrWhiteSpace(ipsoFar))
					ipsoFar += ".";
				ipsoFar += quartet;
				RestoreIpAddressBackTrack(remaining, numberOfQuartets - 1, ipsoFar, result);
				ipsoFar = strThusFar;
			}
		}
	}
	
	private bool IsValidQuartet(string quartet, int numOfQuartet)
	{
		if(string.IsNullOrEmpty(quartet))
			return false;
		//convert to int		
		int val = Int32.Parse(quartet);		
		if(val == 0 && quartet.Length == 1)
			return true;
		if(val > 0 && val <= 255 && quartet[0] != '0')
			return true;
		return false;
	}
}