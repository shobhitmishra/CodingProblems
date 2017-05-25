<Query Kind="Program" />

void Main()
{
	var ob = new Solution();
	//for (int i = -10; i < 10; i++)
	{
		ob.MyPow(1, 2147483647).Dump();
	}
}

// Define other methods and classes here
public class Solution
{
	public double MyPow(double x, int n)
	{		
		if(x == 0)
			return 0;	
		long pow = n;
		
		if (pow < 0)
		{				
			return 1 / MyPowHelper(x, -pow);
		}		
		return MyPowHelper(x,pow);
	}
	
	private double MyPowHelper(double x, long n)
	{
		if(n == 0)
			return 1;
		if(n == 1)
			return x;
		
		var halfPow = MyPowHelper(x, n/2);
		
		var fullPow = halfPow * halfPow;
		
		if(n % 2 == 1)
			fullPow *= x;
			
		return fullPow;
	}
}