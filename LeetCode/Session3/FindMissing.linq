<Query Kind="Program">
  <Namespace>System.IO</Namespace>
</Query>

void Main()
{
	var nums = new int[] {9,6,4,2,3,5,7,0,1};
	var ob = new Solution();
	ob.MissingNumber(nums).Dump();
}

// Define other methods and classes here
public class Solution
{
	public int MissingNumber(int[] nums)
	{
		// xor the existing numbers
		var xorOfNums = nums.Aggregate((x,y) => x^y);
		var xorOfOneToN = Enumerable.Range(1,nums.Length).Aggregate((x,y) => x^y);
		return xorOfNums ^ xorOfOneToN;
	}
}