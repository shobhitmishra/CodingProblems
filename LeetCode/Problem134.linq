<Query Kind="Program" />

void Main()
{
	var gas = new int[] { 1,2,3,3};
	var cost = new int[] {2,1,5,1};
	var ob = new Solution();
	ob.CanCompleteCircuit(gas, cost).Dump();
}

// Define other methods and classes here
public class Solution
{
	public int CanCompleteCircuit(int[] gas, int[] cost)
	{
		int length = gas.Length;
		int i = 0;
		while (i < length)
		{
			int j = IndexWhereBecomesNegative(i, gas, cost);
			if(j == -1)
				return i;
			if(j < i)
				return -1;
			i = j + 1;
		}
		return -1;
	}	
	
	private int IndexWhereBecomesNegative(int ind, int[] gas, int[] cost)
	{
		int length = gas.Length;
		int sum = 0;
		for (int i = 0; i < length; i++)
		{
			int index = (ind + i)% length;
			sum += (gas[index] - cost[index]);
			if(sum < 0)
				return index;
		}
		return -1;
	}
}