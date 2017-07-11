<Query Kind="Program" />

void Main()
{
	var ob = new Solution();
	var input = new int[] { 1,2,3,4,5};
	ob.CombinationSum(input, 7).Dump();
}

// Define other methods and classes here
public class Solution
{
	public IList<IList<int>> CombinationSum(int[] candidates, int target)
	{
		var result = new List<IList<int>>();
		Array.Sort(candidates);
		CombinationSumHelper(candidates, target, 0, new List<int>(), result);
		return result;
	}
	private void CombinationSumHelper(int[] candidates, int target, int index, 
	List<int> tempResult, List<IList<int>> result)
	{
		if (target == 0)
		{
			result.Add(tempResult);
			return;
		}
		if(target < 0)
			return;
		for (int i = index; i < candidates.Length; i++)
		{
			var resultClone = new List<int>(tempResult);
			resultClone.Add(candidates[i]);
			CombinationSumHelper(candidates, target - candidates[i], i, resultClone, result);
		}		
	}
}