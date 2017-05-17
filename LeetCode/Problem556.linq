<Query Kind="Program" />

void Main()
{
	var ob = new Solution();
	ob.NextGreaterElement(1999999999).Dump();
}

// Define other methods and classes here
public class Solution
{
	public int NextGreaterElement(int n)
	{
		var l = new List<int>();
		while (n > 0)
		{
			l.Add(n % 10);
			n = n / 10;
		}
		l.Reverse();
		var r = GetNextLexicogrpahicNumber(l);
		if(r == null)
			return -1;
		long result = 0;
		foreach (var element in r)
		{
			result = result * 10 + element;
			if(result > Int32.MaxValue)
				return -1;
		}
		return (int) result;
	}
	private List<int> GetNextLexicogrpahicNumber(List<int> nums)
	{
		// find K
		var k = FindK(nums);
		if(k == -1)
			return null;
		
		var l = FindL(nums, k);
		Swap(nums, k -1 , l);		
		
		int firstPtr = k;
		int secondPtr = nums.Count - 1;
		while (firstPtr < secondPtr)
		{
			Swap(nums,firstPtr,secondPtr);
			firstPtr++;
			secondPtr--;
		}
		return nums;
	}

	private void Swap(List<int> nums, int k , int l)
	{
		var temp = nums[k];
		nums[k] = nums[l];
		nums[l] = temp;
	}
	
	private int FindK(List<int> nums)
	{
		for (int i = nums.Count -1; i > 0; i--)
		{
			if(nums[i] > nums[i-1])
				return i;
		}
		return -1;
	}
	
	private int FindL(List<int> nums, int k)
	{
		for (int i = nums.Count - 1; i >= k; i--)
		{
			if (nums[i] > nums[k - 1])
				return i;
		}
		return k;
	}
}