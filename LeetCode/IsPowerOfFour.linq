<Query Kind="Program" />

void Main()
{
	var ob = new Solution();
	long mask = 1;
	while((mask << 2) < Int32.MaxValue)
	{
		mask = mask << 2;
		ob.IsPowerOfFour((int)mask).Dump();
	}
}

// Define other methods and classes here
public class Solution 
{
    public bool IsPowerOfFour(int num) 
	{
        if((num & (num - 1)) != 0)
			return false;
		int mask = 0x55555555;
		if((num & mask) == 0)
			return false;
		return true;
    }
}