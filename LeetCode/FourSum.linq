<Query Kind="Program" />

void Main()
{
	var ob = new Solution();
	var nums = new int[]{1, 0, -1, 0, -2, 2};
	int target = 1;
	ob.FourSum(nums, target).Dump();
}

// Define other methods and classes here
public class Solution {

	public List<List<int>> TwoSum(int start, int[] nums, int target)
	{	
		List<List<int>> solution = new List<List<int>>();
		
		int end = nums.Length - 1;
		while(start < end)
		{
			if(nums[start] + nums[end] == target)
			{
				solution.Add(new List<int>(){nums[start], nums[end]});
				start++;
				end--;
				
				//skip the duplicates
				while(start  < end && nums[start] == nums[start - 1])
					start++;
				while(start  < end && nums[end] == nums[end + 1])
					end--;					
			}
			else if(nums[start] + nums[end] < target)
				start++;
			else
				end--;
		}
		
		return solution;
	}
	
    public IList<IList<int>> FourSum(int[] nums, int target) 
	{
        IList<IList<int>> solution = new List<IList<int>>();
		
        //Sort the Array
		Array.Sort(nums);
		
		// Loop for the first number
		for (int i = 0; i < nums.Length - 3; i++)
		{
			if(i > 0 && nums[i] == nums[i-1])
				continue;
			
			for (int j = i + 1; j < nums.Length - 2; j++)
			{
				if(j > i + 1 && nums[j] == nums[j -1])
					continue;
				
				int modTarget = target - nums[i] - nums[j];
				var twoSumList = TwoSum(j + 1, nums, modTarget);
				if(twoSumList.Count > 0)
				{
					foreach (var element in twoSumList)
					{
						solution.Add(new List<int>(){
						nums[i], nums[j], element[0], element[1]});
					}
				}
			}
		}
		return solution;
    }
}