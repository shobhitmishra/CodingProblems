<Query Kind="Program" />

void Main()
{
	var nums = new int[] { 1, 2, 3};
	MissingNumber(nums).Dump();
}

// Define other methods and classes here
public int MissingNumber(int[] nums)
{
	long n = nums.LongLength;
	long sum = nums.Sum();
	long missingNum = (n*(n+1) / 2) - sum;
	return (int)missingNum;
}