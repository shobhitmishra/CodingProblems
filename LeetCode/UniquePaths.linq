<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.Numerics.dll</Reference>
  <Namespace>System.Numerics</Namespace>
</Query>

void Main()
{
	var ob = new Solution();
	ob.UniquePaths(51,9).Dump();
}

// Define other methods and classes here
public class Solution
{
	public int UniquePaths(int m, int n)
	{
		int solution = 0;
		BigInteger numerator = CalculateFactorial(m + n - 2);
		BigInteger mfac = CalculateFactorial(m - 1);
		BigInteger nfac = CalculateFactorial(n - 1);
		BigInteger result = numerator / (mfac * nfac);
		solution = (int)result;
		return solution;
	}

	public BigInteger CalculateFactorial(int m)
	{
		BigInteger solution = 1;
		for (int i = m; i > 0; i--)
		{
			solution *= i;
		}
		return solution;
	}
	public int UniquePathsCorrect(int m, int n)
	{
		// Compute C((m-1)+(n-1), (m-1))
		m--; n--;
		int mn = m + n;
		double ans = 1;
		for (int i = 0; i < m; i++)
			ans = ans * ((double)(mn - i) / (m - i));
		return (int)Math.Round(ans);
	}
}