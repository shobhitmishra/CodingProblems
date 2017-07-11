<Query Kind="Program" />

void Main()
{
	var ob = new Solution();
	var input = new int[] { 10, 1, 2, 7, 6, 1, 5 };
	ob.CombinationSum2(input, 8).Dump();
}

// Define other methods and classes here
public class Solution
{
	public IList<IList<int>> CombinationSum2(int[] candidates, int target)
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
		if (target < 0)
			return;
		for (int i = index; i < candidates.Length; i++)
		{
			if(i > index && candidates[i] == candidates[i-1])
				continue;
			var resultClone = new List<int>(tempResult);
			resultClone.Add(candidates[i]);
			CombinationSumHelper(candidates, target - candidates[i], i + 1, resultClone, result);
		}
	}
}