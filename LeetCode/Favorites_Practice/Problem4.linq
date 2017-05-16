<Query Kind="Program" />

void Main()
{
	var nums1 = new int[] { 1, 2 };
	var nums2 = new int[] { 3, 4};
	var ob = new Solution();
	ob.FindMedianSortedArrays(nums1, nums2).Dump();
}

// This is one of the most tricky problems of Binary search and it is fraught with 
// apotential off by one errors.
// Basic idea is to keep dividing the arrays in such a way that left of arr 1 and left of arr 2
// are equal in size and the largest of either left is less than or equal to smallest of either right
// e.g if arr 1 is cut at i (i is on right) and arr 2 is cut at j (j is in right sub arr)
// then i + j = (m + n + 1)/ 2 && A[i-1] <= B[j] && B[j-1] <= A[i]
// if these conditions are not satified then keep moving the cutting point in 
// smaller array to left or right until these conditions are satisfied
public class Solution
{
	// nums1 should be smaller than nums2	
	public double FindMedianSortedArrays(int[] nums1, int[] nums2)
	{
		if(nums1.Length > nums2.Length)
			return FindMedianSortedArrays(nums2, nums1);
		
		int m = nums1.Length;
		int n = nums2.Length;
		int halfLength = (m + n + 1)/2;
		int iMin = 0; int iMax = m;

		while (iMin <= iMax)
		{
			var i = (iMin + iMax)/2;
			var j = halfLength - i;
			
			// three cases
			if(i < m && nums1[i] < nums2[j-1])
				iMin = i + 1;
			else if(i > 0 && nums1[i-1] > nums2[j])
				iMax = i - 1;
			else
			{
				// either we have reached the boundary or we found the element
				var maxLeft = 0;
				if(i == 0) maxLeft = nums2[j-1];
				else if(j == 0) maxLeft = nums1[i -1];
				else maxLeft = Math.Max(nums1[i-1], nums2[j-1]);
				
				if((m + n) % 2 != 0)
					return maxLeft;
					
				var minRight = 0;
				if(i == m) minRight = nums2[j];
				else if(j == n) minRight = nums1[i];
				else minRight = Math.Min(nums1[i], nums2[j]);
				
				return (maxLeft + minRight) / 2.0;
			}
		}
		return 0;
	}
}