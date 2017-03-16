<Query Kind="Program" />

void Main()
{
	var nums = new int[] { 1, 1};
	var ob = new Solution();
	ob.FirstMissingPositive(nums).Dump();
}

// Define other methods and classes here
public class Solution
{
	public int FirstMissingPositive(int[] nums)
	{
		if(nums == null || nums.Length == 0)
			return 1;
		int[] arr = new int[nums.Length + 1];
		Array.Copy(nums, 0, arr, 1, nums.Length);
		for (int i = 1; i <= nums.Length; i++)
		{
			if(arr[i] == i || arr[i] <= 0 || arr[i] >= nums.Length)
				continue;
			while (arr[i] != i)
			{
				if(arr[i] <= 0 || arr[i] >= nums.Length)
					break;
				if(arr[arr[i]] != arr[i])
					Swap(ref arr[i], ref arr[arr[i]]);
				else
					break;
			}
		}
		for (int i = 1; i <= nums.Length; i++)
		{
			if(arr[i] != i)
				return i;
		}
		return nums.Length + 1;
	}

	public void Swap(ref int a, ref int b)
	{
		int temp = a;
		a = b;
		b = temp;
	}
}