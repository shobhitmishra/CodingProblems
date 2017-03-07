<Query Kind="Program" />

void Main()
{
	Console.WriteLine (RangeBitwiseAnd(2,3));
}

// Define other methods and classes here
public int RangeBitwiseAnd(int m, int n) {		
		// We need to find the common header of m and n. Only those bits will remain unchanged from m to n.
		// Rest everything will be 0 at least once. 
		// To find common header, keep shifting both to right until m = n and keep the shiftCount
		// then shift m to the left by shiftCount. 
		int shift = 0;
		while (m != n)
		{
			m >>= 1;
			n >>= 1;
			shift++;
		}
		return m << shift;
}