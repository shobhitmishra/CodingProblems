<Query Kind="Program" />

void Main()
{
	
}

// Define other methods and classes here
public class Solution
{
	public void Merge(int[] nums1, int m, int[] nums2, int n)
	{
		int i = m-1;
		int j = n-1;
		int k = m + n - 1;
		while (i >= 0 && j >= 0)
		{
			nums1[k--] = nums1[i] > nums2[j] ? nums1[i--] : nums2[j--];
		}
		while (j >= 0)
		{
			nums1[k--] = nums2[j--];
		}
	}
}