<Query Kind="Program" />

void Main()
{
	var ob = new Solution();
	ob.CountDigitOne(100).Dump();
}

// Define other methods and classes here
public class Solution 
{
	Dictionary<long,int> digitCountDict = new Dictionary<long,int>();
    public int CountDigitOne(int n) 
	{   		
		int power = 1;
		long num = 10;
		while(num < Int32.MaxValue)
		{
			digitCountDict.Add(num - 1, (int)(power * num / 10));
			num *= 10;
			power++;
		}
		
		return CountDigitOneHelper(n);
    }
	
	private int CountDigitOneHelper(int n)
	{
		if(n <= 0)
			return 0;
		if(n < 10)
			return 1;
		int result = 0;
		int divisor = GetDivisor(n);
		result += n / divisor * digitCountDict[divisor -1];
		result += (n / divisor) == 1 ? n % divisor + 1 : divisor; 
		result += CountDigitOneHelper(n % divisor);
		return result;
	}
	
	private int GetDivisor(int n)
	{
		int divisor = 1;
		while(n / 10 >= 1)
		{
			n = n / 10;
			divisor *= 10;
		}
		return divisor;
	}
}