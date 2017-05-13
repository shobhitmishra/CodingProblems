<Query Kind="Program" />

void Main()
{
	var input = new int[] {4,5,5,6};
	var ob = new Solution();
	ob.WiggleSort(input);
	input.Dump();
}

// Define other methods and classes here
public class Solution
{
	public void WiggleSort(int[] nums)
	{
		Array.Sort(nums);
		var result = new int[nums.Length];
		int sortPtr = 0;
		// fill the even positions
		for (int i = 0; i < nums.Length; i = i +2)
		{
			result[i] = nums[sortPtr++];
		}
		
		// fill the odd positions
		for (int i = 1; i < nums.Length; i = i+2)
		{
			result[i] = nums[sortPtr++];
		}		
		SwapIfTwoNeigborsAreEqual(result);
		Array.Copy(result, nums, result.Length);
	}

	private void SwapIfTwoNeigborsAreEqual(int[] result)
	{
		bool neigborsEqual = false;
		for (int i = 0; i < result.Length - 1; i++)
		{
			if (result[i] == result[i + 1])
			{
				neigborsEqual = true;
				break;
			}
		}
		if (neigborsEqual)
		{
			Array.Reverse(result);
			for (int i = 0; i + 1 < result.Length; i = i + 2)
			{
				int temp = result[i];
				result[i] = result[i + 1];
				result[i + 1] = temp;
			}
		}
	}
}