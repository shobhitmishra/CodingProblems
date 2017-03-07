<Query Kind="Program" />

void Main()
{
	var ob = new Solution();
	var nums1 = new int[]{1,2};
	var nums2 = new int[] {};
	ob.FindMedianSortedArrays(nums1, nums2).Dump();
}

// Define other methods and classes here
public class Solution 
{
    public double FindMedianSortedArrays(int[] nums1, int[] nums2) 
	{
        int n1 = nums1.Length;
		int n2 = nums2.Length;
		
		if(n2 > n1)
			return FindMedianSortedArrays(nums2, nums1);
		
		if(n2 == 0)
			return ((double)nums1[(n1-1)/2] + (double)nums1[n1/2])/2;
			
		int lo = 0;
		int hi = 2 * n2;
		while(lo <= hi)
		{
			int mid2 = (lo + hi) /2;
			int mid1 = n1 + n2 - mid2;
			
			double l1 = (mid1 == 0) ? Int32.MinValue : nums1[(mid1-1)/2];
			double r1 = (mid1 == 2 * n1) ? Int32.MaxValue : nums1[mid1/2];
			double l2 = (mid2 == 0) ? Int32.MinValue : nums2[(mid2-1)/2];
			double r2 = (mid2 == 2 * n2) ? Int32.MaxValue : nums2[mid2/2];
			
			if(l1 > r2) lo = mid2 + 1;
			else if(l2 > r1) hi = mid2 - 1;
			else return (Math.Max(l1,l2) + Math.Min(r1,r2))/2;
		}
		return -1;
    }
}