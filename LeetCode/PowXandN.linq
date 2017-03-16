<Query Kind="Program" />

void Main()
{
	var ob = new Solution();
	var result = ob.MyPow(8.88023, 3);
	Console.WriteLine(result);
//	for (int i = 0; i <= 10; i++)
//	{
//		var result = ob.MyPow(3,i);
//		Console.WriteLine(result);
//	}
}

// Define other methods and classes here
public class Solution
{
	public double MyPow(double x, int n)
	{
		if (x == 0)
			return 0;
		if (n == 0)
			return 1;
		if (n == 1)
			return x;		
		var result = MyPowHelper(x, Math.Abs((long)n));
		
		if(n < 0)
			return 1 / result;
		return result;
	}

	public double MyPowHelper(double x, long n)
	{
		if(x == 0)
			return 0;
		if(n == 0)
			return 1;
		if(n == 1)
			return x;
		
		var halfPow = MyPowHelper(x,n/2);
		
		var fullPow = halfPow * halfPow;
		if(n % 2 == 1)
			fullPow *= x;
		
		return fullPow;
	}
}