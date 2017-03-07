<Query Kind="Program" />

void Main()
{
	var ob = new Solution();
	for (int i = 1; i < 3999; i++)
	{
		var roman = ob.IntToRoman(i);
		var number = ob.RomanToInt(roman);
		
		Console.WriteLine("original {0}, roman {1}, integer {2}",i,roman,number);
		if(i != number)
			throw new ArgumentException("gadbad");
	}
}

// Define other methods and classes here
public class Solution 
{
    public string IntToRoman(int num) 
	{
        if (num < 1 || num > 3999) 
			return "";
		
		string[] roman = {"M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I"};
    	int[] values = {1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1 };
		
		int i = 0;
		string result = "";
		while (num >0) 
		{
			while ( num >= values[i]) 
			{
				num -= values[i];
				result += roman[i];
			}
			i++;
    	}
		return result;
    }
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