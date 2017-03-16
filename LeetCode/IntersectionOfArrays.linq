<Query Kind="Program" />

void Main()
{
	var input1 = new int[] { 1, 2, 2, 1 };
	var input2 = new int[] { 1, 2, 2};
	var ob = new Solution();
	ob.Intersect(input1, input2).Dump();
}

// Define other methods and classes here
public class Solution
{
	public int[] Intersect(int[] nums1, int[] nums2)
	{
		if(nums1 == null || nums2 == null)
			return new int[0];
		var result = new List<int>();
		Array.Sort(nums1);
		Array.Sort(nums2);
		int ptr1 = 0;
		int ptr2 = 0;
		while (ptr1 < nums1.Length && ptr2 < nums2.Length)
		{
			if (nums1[ptr1] == nums2[ptr2])
			{
				result.Add(nums1[ptr1]);
				ptr1++;
				ptr2++;
			}
			else if(nums1[ptr1] < nums2[ptr2])
				ptr1++;
			else
				ptr2++;
		}		
		return result.ToArray();
	}
}