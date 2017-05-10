<Query Kind="Program" />

void Main()
{
	var input = new string[] {"0", " 0.1 ", "2e10",  "3.", "46.e3", ".2e81",
	"1 a", ".", " ", "e9", "e9.", ".e9", "+ 1", "7.e-.", "1e."};
	var ob = new Solution();
	foreach (var element in input)
	{
		ob.IsNumber(element).Dump();
	}
}


// If we see[0 - 9] we reset the number flags.
// We can only see. if we didn't see e or ..
// We can only see e if we didn't see e but we did see a number. We reset numberAfterE flag.
// We can only see + and - in the beginning and after an e
// any other character break the validation.
// Define other methods and classes here
public class Solution
{	
	public bool IsNumber(string s)
	{
		s = s.Trim();		
		bool dotSeen = false;
		bool eSeen = false;
		bool digitSeen = false;
		bool numberAfterE = true;
		for (int i = 0; i < s.Length; i++)
		{
			var ch = s[i];
			if (ch >= '0' && ch <= '9')
			{
				digitSeen = true;
				numberAfterE = true;
			}
			else if (ch == '.')
			{
				if(dotSeen || eSeen)
					return false;
				dotSeen = true;
			}
			else if (ch == 'e')
			{
				if(eSeen || !digitSeen)
					return false;
				eSeen = true;
				numberAfterE = false;
			}
			else if (ch == '+' || ch == '-')
			{
				if(i != 0 && s[i-1] != 'e')
					return false;
			}
			else
			{
				return false;
			}
		}		
		return digitSeen && numberAfterE;
	}
}