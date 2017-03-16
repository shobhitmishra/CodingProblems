<Query Kind="Program" />

void Main()
{
	var input = new int[] {0};
	var ob = new Solution();
	ob.SortColors(input);
	input.Dump();
}

// Define other methods and classes here
public class Solution
{
	public void SortColors(int[] nums)
	{
		int zeroPtr = 0;
		int onePtr = 0;
		int twoPtr = nums.Length - 1;
		while (onePtr <= twoPtr)
		{
			if (nums[onePtr] == 0 && onePtr > zeroPtr)
			{
				Swap(zeroPtr++, onePtr, nums);				
			}
			else if(nums[onePtr] == 2 && onePtr < twoPtr)
			{
				Swap(onePtr, twoPtr--, nums);				
			}
			else
				onePtr++;
		}
	}
	private void Swap(int i, int j, int[] arr)
	{
		int temp = arr[i];
		arr[i] = arr[j];
		arr[j] = temp;
	}
}