<Query Kind="Program" />

void Main()
{
	var ob = new Solution();
	ob.NthUglyNumber(10).Dump();
}

// Define other methods and classes here
public class Solution
{
	public int NthUglyNumber(int n)
	{
		var uglyNums = new List<long>() { 0, 1};
		if(n < 2)
			return 1;
		int ptr2 = 1;
		int ptr3 = 1;
		int ptr5 = 1;
		for (int i = 2; i <= n; i++)
		{
			var ithUglyNum = Math.Min(2 * uglyNums[ptr2], Math.Min(3 * uglyNums[ptr3], 5 * uglyNums[ptr5]));
			uglyNums.Add(ithUglyNum);
			
			if(2 * uglyNums[ptr2] == ithUglyNum)
				ptr2++;
			if (3 * uglyNums[ptr3] == ithUglyNum)
				ptr3++;
			if (5 * uglyNums[ptr5] == ithUglyNum)
				ptr5++;
		}
		return (int)uglyNums[n];
	}
}