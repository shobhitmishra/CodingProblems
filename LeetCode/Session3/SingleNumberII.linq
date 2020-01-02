<Query Kind="Program">
  <Namespace>static System.Linq.Enumerable</Namespace>
  <Namespace>System.IO</Namespace>
</Query>

void Main()
{
	var ob = new Solution();
	var nums = new int[] {-2,-2,1,1,-3,1,-3,-3,-4,-2};
	ob.SingleNumber(nums).Dump();
}

// Define other methods and classes here
public class Solution
{
	public int SingleNumber(int[] nums)
	{
		int result = 0, i = 0, mask = 1;		
		while(i < 32)
		{
			var count = nums.Select(x => x & mask).Where(x => x!=0).Count();
			result = result | (count % 3 == 0 ? 0 : mask);
			mask = mask <<1;
			i++;
		}
		return result;
	}
}