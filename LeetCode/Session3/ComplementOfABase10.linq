<Query Kind="Program">
  <Namespace>static System.Linq.Enumerable</Namespace>
  <Namespace>System.IO</Namespace>
</Query>

void Main()
{
	var ob = new Solution();
	ob.BitwiseComplement(5).Dump();
}

// Define other methods and classes here
public class Solution
{
	public int BitwiseComplement(int N)
	{
		if(N == 0)
			return 1;
		var powerOfTwo = 1;
		while(powerOfTwo <= N)
			powerOfTwo = powerOfTwo << 1;
		// set all the bits
		return N^(powerOfTwo-1);
	}
}