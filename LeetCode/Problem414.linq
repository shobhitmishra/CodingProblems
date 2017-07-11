<Query Kind="Program" />

void Main()
{
	var ob = new Solution();
	var input = new int[] {1,2,-2147483648};
	ob.ThirdMax(input).Dump();
}

// Define other methods and classes here
public class Solution
{
	public int ThirdMax(int[] nums)
	{
		var heap = Enumerable.Repeat(long.MinValue, 3).ToArray();
		int count = 0;
		foreach (var num in nums)
		{
			if (num > heap[0] && !heap.Contains(num))
			{
				heap[0] = num;
				Array.Sort(heap);
				count++;
				count = Math.Min(3,count);
			}
		}
		return count < 3 ? (int)heap.Max() : (int)heap[0];
	}
}