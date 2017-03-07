<Query Kind="Program" />

void Main()
{
	var ob = new Solution();
	ob.RomanToInt("V").Dump();
}

// Define other methods and classes here
public class Solution 
{
    public int RomanToInt(string s) 
	{
        var romanDict = new Dictionary<string, int>(){
		{"I", 1},
		{"V", 5},
		{"X", 10},
		{"L", 50},
		{"C", 100},
		{"D", 500},
		{"M", 1000}};
		int result = 0;
		for (int i = 0; i < s.Length; i++)
		{			
			int currentVal = romanDict[s[i].ToString()];
			if(i < s.Length - 1)
			{
				if(currentVal < romanDict[s[i+1].ToString()])
					currentVal *=-1;
			}
			result += currentVal;
		}
		return result;
    }
}