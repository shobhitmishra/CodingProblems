<Query Kind="Program" />

void Main()
{
	
}

// Define other methods and classes here
public class Solution
{
	public int NumWays(int n, int k)
	{
		if(n == 0 || k == 0)
			return 0;
		if(n > 2 && k == 1)
			return 0;		
		int w1 = k;
		int w2 = k * k;
		int w3 = 0;
		if(n == 1)
			return w1;
		if(n == 2)
			return w2;
		for (int i = 3; i <=n; i++)
		{
			w3 = (w1 + w2) * (k-1);
			w1 = w2;
			w2 = w3;
		}
		return w2;
	}
}