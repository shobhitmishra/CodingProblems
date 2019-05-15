<Query Kind="Program" />

void Main()
{
	
}

// Define other methods and classes here
public class Solution
{
	public double FindMedianSortedArrays(int[] nums1, int[] nums2)
	{
		if(nums1.Length > nums2.Length)
			return FindMedianSortedArrays(nums2, nums1);
			
		var m = nums1.Length;
		var n = nums2.Length;
				
		// The left half of combined array will have as many or one more element than right half of 
		var half = (m + n + 1) / 2;
		
		// Do a binary search in the shorter array
		var mStart = 0;
		var mEnd = m;
		while(mStart <= mEnd)
		{
			var i = (mStart + mEnd) / 2; // the partition point in nums1
			var j = half - i; // the partition point in nums2;
			
			// numbers will be nums1[i-1], nums1[i] and nums2[j-1], nums2[j]
			// Adjust the mid point
			if(i > 0 && nums1[i-1] > nums2[j]) // too much on the right
				mEnd = i -1;
			else if(i < m && nums1[i] < nums2[j-1]) // too much on the left
				mStart = i + 1;
			else // we have either reached the boundary or found our element
			{
				var maxLeft = 0;
				if(i <= 0) maxLeft = nums2[j-1];
				else if(j <= 0) maxLeft = nums1[i-1];
				else maxLeft = Math.Max(nums1[i-1], nums2[j-1]);
				
				// if total number of elements are odd then the last element of left partition is the median
				if((m + n) % 2 != 0)
					return maxLeft;
					
				var minRight = 0;
				if(i >= m) minRight = nums2[j];
				else if(j >= n) minRight = nums1[i];
				else minRight = Math.Min(nums1[i], nums2[j]);
				
				return (maxLeft + minRight) / 2.0;
			}
		}
		
		return 0;
	}
}