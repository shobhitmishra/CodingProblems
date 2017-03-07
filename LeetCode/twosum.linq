<Query Kind="Program" />

void Main()
{
	var ob = new Solution();
	var nums = new int[]{2, 7, 11, 15, 7, 4, 5, 1, 8, 6};
	var zeros = new int[] {0,0,0,0};
	int target = 0;
	ob.TwoSumAll(zeros, target).Dump();
}

// Define other methods and classes here
public class Solution {
	// Returns only one solution
    public int[] TwoSum(int[] nums, int target) 
	{
    	var dict = new Dictionary<int, int>();
		for (int i = 0; i < nums.Length; i++)
		{
			// check if the pair is in dictionary
			if(dict.ContainsKey(target - nums[i]))
			{
				return new int[]{dict[target - nums[i]] + 1, i + 1};
			}
			// if the number is not there
			if(!dict.ContainsKey(nums[i]))
				dict.Add(nums[i], i);
		}
		return null;
    }
	
	// Gives all Solutions
	public List<List<int>> TwoSumAll(int[] nums, int target) 
	{
    	var numsHash = new HashSet<int>();
		List<List<int>> solution = new List<List<int>>();
		
		Array.Sort(nums);
		
		for (int i = 0; i < nums.Length; i++)
		{			
			if(numsHash.Contains(target - nums[i]))
			{
				var tempList = new List<int>(){target - nums[i], nums[i]};
				if(solution.Count == 0)
					solution.Add(tempList);
				else
				{
					var lastList = solution.Last();
					if(!Enumerable.SequenceEqual(tempList, lastList))
						solution.Add(tempList);
				}
			}
			
			numsHash.Add(nums[i]);
		}
		return solution;
    }
}