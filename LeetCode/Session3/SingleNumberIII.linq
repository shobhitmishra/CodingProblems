<Query Kind="Program">
  <Namespace>static System.Linq.Enumerable</Namespace>
  <Namespace>System.IO</Namespace>
</Query>

void Main()
{
	var ob = new Solution();
	var input = new int[] {1,2,1,3,2,5};
	ob.SingleNumber(input).Dump();
}

// Define other methods and classes here
public class Solution
{
	public int[] SingleNumber(int[] nums)
	{
		// find a position which is set in the first unique number but not the other one
		// Xor all the numbers. the resulting number will be Xor of num1(unique) and num2(unique)
		var xorOfUniqueNums = nums.Aggregate((x,y) => x^y);
		
		// Create a mask of upto 32 bits i.e 1<<0, 1<<1, 1<<2, ... 1<<31
		var masks = Enumerable.Repeat(1,31)
		.Zip(Enumerable.Range(0,32), (first, second) => first << second);
		
		// Find a position for which the masks and xor of masks is non zero
		var validMask = masks.Where(x => (x&xorOfUniqueNums) != 0).First();
		
		// Create two gorups of orginal number sequence.
		//First in which the mast bit is set and second where it is not set
		var numbersWithSetBit = nums.Where(x=> (x&validMask) == 0);
		var numbersWithBitNotSet = nums.Where(x=> (x&validMask) != 0);
		
		var uniqueNum1 = numbersWithSetBit.Aggregate((x,y) => x^y);
		var uniqueNum2 = numbersWithBitNotSet.Aggregate((x, y) => x ^ y);
		return new int[] {uniqueNum1, uniqueNum2};
	}
}