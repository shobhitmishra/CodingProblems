<Query Kind="Program" />

void Main()
{
	var ob = new Solution();
	var result = ob.SubsetsIterative(new int[] {1,2,2});
	result.Dump();
}

// Define other methods and classes here
public class Solution
{
	public IList<IList<int>> Subsets(int[] nums)
	{
		long setSize = (long)Math.Pow(2,nums.Length);
		var result = new List<IList<int>>();
		for (int counter = 0; counter < setSize; counter++)
		{
			List<int> tempResult = new List<int>();
			for (int i = 0; i < nums.Length; i++)
			{
				//check if the ithbit is set
				if((counter & (1<<i)) > 0)
					tempResult.Add(nums[i]);
			}
			result.Add(tempResult);
		}		
		return result;
	}
	public IList<IList<int>> SubsetsIterative(int[] nums)
	{
		Array.Sort(nums);
		var result = new List<IList<int>>() { new List<int>()};		
		for(int i = 0; i < nums.Length; i++)
		{			
			int num = nums[i];
			var tempResult = new List<IList<int>>(result);
			if (i > 0 && nums[i] == nums[i - 1])
			{
				var lastList = new List<int>(tempResult[tempResult.Count  - 1]);
				lastList.Add(num);
				result.Add(lastList);
			}
			else
			{
				foreach (var list in tempResult)
				{
					var tempList = new List<int>(list);
					tempList.Add(num);
					result.Add(tempList);
				}
			}
		}
		return result;
	}
}