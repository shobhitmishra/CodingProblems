<Query Kind="Program" />

void Main()
{
	var ob = new Solution();
	var input1 = new int[] { 1, 2, 2, 1 };
	var input2 = new int[] { 2, 2};
	ob.Intersection(input1,input2).Dump();
}

// Define other methods and classes here
public class Solution
{
	public int[] Intersection(int[] nums1, int[] nums2)
	{
		var hash1 = new HashSet<int>(nums1);
		var hash2 = new HashSet<int>(nums2);
		return nums1.Intersect(nums2).ToArray();
	}
}