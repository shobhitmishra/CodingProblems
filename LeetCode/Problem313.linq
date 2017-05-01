<Query Kind="Program" />

void Main()
{
	var ob = new Solution();
	var primes = new int[] { 2, 7, 13, 19};
	ob.NthSuperUglyNumber(14,primes);	
}

// Define other methods and classes here
public class Solution
{
	public int NthSuperUglyNumber(int n, int[] primes)
	{
		var uglyNums = new int[n];
		var val = Enumerable.Repeat(1,primes.Length).ToArray();
		var idx = new int[primes.Length];
		
		var next = 1;
		for (int i = 0; i < n; i++)
		{
			uglyNums[i] = next;
			
			next = Int32.MaxValue;
			for (int j = 0; j < primes.Length; j++)
			{
				if (val[j] == uglyNums[i])
				{
					val[j] = primes[j] * uglyNums[idx[j]];
					idx[j]+=1;					
				}
				next = Math.Min(next,val[j]);
			}
		}
		return uglyNums[n-1];
	}
}