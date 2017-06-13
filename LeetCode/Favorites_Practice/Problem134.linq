<Query Kind="Program" />

void Main()
{
	var ob = new Solution();
	var gas = new int[] {7,3,9,1,4};
	var cost = new int[] {5,2,7,7,2};
	ob.CanCompleteCircuit(gas, cost).Dump();
	
}

// Define other methods and classes here
public class Solution
{
	public int CanCompleteCircuit(int[] gas, int[] cost)
	{
		int start = 0;
		int len = gas.Length;
		while (start < len)
		{
			var negativeIndex = GetNegativeIndex(gas, cost, start);			
			if(negativeIndex == -1)
				return start;
			if(negativeIndex < start)
				return -1;
			start = negativeIndex + 1;
		}
		return -1;
	}
	
	private int GetNegativeIndex(int[] gas, int[] cost, int start)
	{
		var cumGas = 0;
		var cumCost = 0;
		var length = gas.Length;
		for (int i = 0; i < length; i++)
		{
			int index = (start + i) % length;
			cumGas += gas[index];
			cumCost += cost[index];
			if(cumCost > cumGas)
				return index;
		}
		return -1;
	}
}