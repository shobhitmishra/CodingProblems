<Query Kind="Program" />

void Main()
{
	var ob = new Solution();
	var array = new int[] {4,6,90,77} ;
	var result = ob.MaximumGap(array);
	result.Dump();
}

// Define other methods and classes here
public class Solution
{
	public int[] RadixSort(int[] nums)
	{			
		int[] result = new int[nums.Length];
		Array.Copy(nums, result, nums.Length);
		int max = nums.Max();
		int mask = 1;

		while (mask <= max && mask > 0)
		{
			var zeroList = new List<int>();
			var oneList = new List<int>();
			for (int i = 0; i < result.Length; i++)
			{			
				if ((result[i] & mask) == 0)
					zeroList.Add(result[i]);
				else
					oneList.Add(result[i]);
			}
			zeroList.AddRange(oneList);
			result = zeroList.ToArray();
			mask = mask <<1;
		}
		return result;
	}
	public int MaximumGap(int[] nums)
	{
		if(nums.Length < 2)
			return 0;
		var sorted = RadixSort(nums);
		int result = 0;
		for (int i = 1; i < sorted.Length; i++)
		{
			result = Math.Max(result, sorted[i] - sorted[i-1]);
		}
		return result;
	}
}