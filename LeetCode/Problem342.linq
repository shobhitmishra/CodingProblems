<Query Kind="Program" />

void Main()
{
	var ob = new Solution();
	for (int i = 0; i <= 15; i++)
	{
		var num = (int)Math.Pow(4, i);
		//Console.WriteLine(Convert.ToString(num,2));
		ob.IsPowerOfFour(num+3).Dump();
	}
}

// Define other methods and classes here
public class Solution
{
	public bool IsPowerOfFour(int num)
	{
		if(num <= 0)
			return false;
		if((num & (num - 1)) != 0)
			return false;
		// count number of zeros
		int b = 1;
		int numOfZeros = 0;
		while (b < num)
		{
			if ((b & num) == 0)
			{		
				numOfZeros++;
			}
			b = b << 1;
		}
		return numOfZeros % 2 == 0;
	}	
}