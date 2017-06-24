<Query Kind="Program" />

void Main()
{
	var input = new int[] {10,1,0,1000};
	var ob = new Solution();
	ob.IncreasingTriplet(input).Dump();
}

// Define other methods and classes here
public class Solution
{
	public bool IncreasingTriplet(int[] nums)
	{		
		var first = int.MaxValue;
		var second = int.MaxValue;
		foreach (var n in nums)
		{
			if (n <= first)
            	first = n;
			else if(n <= second)
            	second = n;
        	else
            	return true;
		}
		return false;
	}
}