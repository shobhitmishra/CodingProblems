<Query Kind="Program" />

void Main()
{
	var input = new int[] { 2, 3, 1, 1, 4};
	var ob = new Solution();
	ob.Jump(input).Dump();
}

// Define other methods and classes here
public class Solution
{
	public int Jump(int[] nums)
	{
		if(nums.Length < 2)
			return 0;
		var jumps = 0;
		var position = 0;
		while (position < nums.Length)
		{
			jumps++;
			var reach = nums[position];
			var next = position + 1;
			for (int i = 1; i <= reach; i++)
			{
				var index = position + i;
				if(index == nums.Length -1)
					return jumps;
				if (index < nums.Length)
				{
					if (index + nums[index] > next + nums[next])
						next = index;
				}
			}
			position = next;
		}
		return jumps;
	}
}