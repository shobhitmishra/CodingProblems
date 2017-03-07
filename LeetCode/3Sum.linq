<Query Kind="Program" />

void Main()
{
	var ob = new Solution();
	var input = new int[]{-1, 0, 1, 2, -1, -4, -1, 0, 0, 1, 1, 2, 2, 2};
	ob.ThreeSum(input).Dump();
}

// Define other methods and classes here
public class Solution 
{
    public IList<IList<int>> ThreeSum(int[] nums) 
	{
        Array.Sort(nums);
		var result = new List<IList<int>>();
		for (int i = 0; i < nums.Length; i++)
		{
			if(i > 0 && nums[i] == nums[i-1])
				continue;
			var requiredSum = -nums[i];
			var twosum = GetTwosum(nums, i + 1, requiredSum);
			
			foreach (var twosumList in twosum)
			{
				var temp = new List<int>() {nums[i]};
				temp.AddRange(twosumList);
				result.Add(temp);
			}
		}
		return result;
    }
	
	public IList<IList<int>> GetTwosum(int[] nums, int start, int requiredSum)
	{
		var result = new List<IList<int>>();
		int front = start;
		int back = nums.Length -1;
		while(front < back)
		{
			if(front > start && nums[front] == nums[front -1])
			{
				front++;
				continue;
			}
			if(back < nums.Length - 1 && nums[back] == nums[back + 1])
			{
				back--;
				continue;
			}
			int sum = nums[front] + nums[back];
			if(sum == requiredSum)
				result.Add(new List<int>(){nums[front++], nums[back--]});
			else if(sum < requiredSum)
				front++;
			else
				back--;
		}
		return result;
	}
}