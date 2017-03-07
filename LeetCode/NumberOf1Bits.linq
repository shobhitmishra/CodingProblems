<Query Kind="Program" />

void Main()
{
	var ob = new Solution();
	ob.HammingWeight(11).Dump();
}

// Define other methods and classes here
public class Solution 
{
    public int HammingWeight(uint n) 
	{
        int count = 0;
		int mask = 1;
		for (int i = 0; i <= 32; i++)
		{
			if((n&mask) != 0)
				count++;
			mask = mask<<1;
		}
		return count;
    }
}