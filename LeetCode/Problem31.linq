<Query Kind="Program" />

void Main()
{
	var ob = new Solution();
	var input = new int[] { 1, 2, 3, 4, 5, 6};
	for (int i = 0; i < 10; i++)
	{
		ob.NextPermutation(input);
		input.Dump();
	}
}

// Define other methods and classes here
public class Solution
{
	public void NextPermutation(int[] nums)
	{
		// Find righmost K such that nums[K] > nums[k-1]
		// if no such K exists then nums is already maximum
		int k = FindK(nums);
		if (k == -1)
		{
			Array.Sort(nums);
			return;
		}
		
		// Find rightmost L after K such that nums[L] > Nums[K-1]
		int l = FindL(nums, k-1);
		
		// swap K-1 and L elements
		int temp = nums[k-1];
		nums[k-1] = nums[l];
		nums[l] = temp;
		
		// sort/reverse everything after and including k
		//Array.Sort(nums, k, nums.Length - k);		
		int firstPtr = k;
		int lastPtr = nums.Length - 1;
		while (firstPtr < lastPtr)
		{
			// swap the two
			int swap = nums[firstPtr];
			nums[firstPtr] = nums[lastPtr];
			nums[lastPtr] = swap;
			firstPtr++;
			lastPtr--;
		}
	}
	
	private int FindK(int[] nums)
	{
		for (int i = nums.Length -1; i > 0 ; i--)
		{
			if(nums[i] > nums[i-1])
				return i;
		}
		return -1;
	}
	
	private int FindL(int[] nums, int k)
	{
		for (int i = nums.Length -1; i >= k+1 ; i--)
		{
			if(nums[i] > nums[k])
				return i;
		}
		return k+1;
	}
}