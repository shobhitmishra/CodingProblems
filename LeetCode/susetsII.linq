<Query Kind="Program" />

void Main()
{
	var ob = new Solution();
	var nums = new int[] { 1, 2, 2, 2};
	var result = ob.SubsetsWithDup(nums);
	result.Dump();
}

// Define other methods and classes here
public class Solution
{
	public IList<IList<int>> SubsetsWithDup(int[] nums)
	{
		Array.Sort(nums);
		var result = new List<IList<int>>() { new List<int>()};
		var intermediateResults = new List<IList<int>>() { new List<int>()};
		for (int i = 0; i < nums.Length; i++)
		{
			var tempResult = new List<IList<int>>();
			foreach (var list in intermediateResults)
			{
				var listCopy = new List<int>(list);
				listCopy.Add(nums[i]);
				tempResult.Add(listCopy);
			}
			result.AddRange(tempResult);
			if(i < nums.Length - 1 && nums[i + 1] == nums[i])
				intermediateResults = new List<IList<int>>(tempResult);
			else
				intermediateResults = new List<IList<int>>(result);
		}
		return result;
	}
}