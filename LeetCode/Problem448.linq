<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.IO.dll</Reference>
</Query>

void Main()
{
	var input = new int[] {4,3,2,7,8,2,3,1 };
	var ob = new Solution();
	ob.FindDisappearedNumbers(input).Dump();
}

// Define other methods and classes here
public class Solution
{
	public List<int> FindDisappearedNumbers(int[] nums)
	{
		var result = new List<int>();
		var size = nums.Length + 1;
		for (int i = 0; i < nums.Length; i++)
		{
			int originalNumber = nums[i] % size;
			// update the index
			nums[originalNumber - 1] += size;			
		}
		
		for (int i = 0; i < nums.Length; i++)
		{
			if(nums[i] < size)
				result.Add(i + 1);
		}
		return result;
	}
}