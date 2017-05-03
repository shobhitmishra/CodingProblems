<Query Kind="Program" />

void Main()
{
	var input = new int[] { 1, 1, 2, 3};
	var ob = new Solution();
	ob.PermuteUnique(input).Dump();
}

// Define other methods and classes here
public class Solution
{
	public IList<IList<int>> PermuteUnique(int[] nums)
	{
		var hash = new HashSet<string>();
		var result = new List<IList<int>>();
		Array.Sort(nums);
		var sorted = new int[nums.Length];
		Array.Copy(nums, sorted, nums.Length);
		do
		{
			if (hash.Add(GetString(nums)))
			{
				result.Add(new List<int>(nums));
			}
			NextPermutation(nums);
		}while(AreEquals(nums,sorted) == false);
		
		return result;
	}
	
	private bool AreEquals(int[] arr1, int[] arr2)
	{
		if(arr1.Length != arr2.Length)
			return false;
		for (int i = 0; i < arr1.Length; i++)
		{
			if(arr1[i] != arr2[i])
				return false;
		}
		return true;
	}
	
	private string GetString(int[] nums)
	{
		return string.Join("", nums);
	}
	
	private void NextPermutation(int[] nums)
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
		int l = FindL(nums, k - 1);

		// swap K-1 and L elements
		int temp = nums[k - 1];
		nums[k - 1] = nums[l];
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
		for (int i = nums.Length - 1; i > 0; i--)
		{
			if (nums[i] > nums[i - 1])
				return i;
		}
		return -1;
	}

	private int FindL(int[] nums, int k)
	{
		for (int i = nums.Length - 1; i >= k + 1; i--)
		{
			if (nums[i] > nums[k])
				return i;
		}
		return k + 1;
	}
}