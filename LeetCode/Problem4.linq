<Query Kind="Program" />

void Main()
{
	
}

// Define other methods and classes here
public class Solution
{
	public double FindMedianSortedArrays(int[] nums1, int[] nums2)
	{
		int nStart, mStart, nEnd, mEnd;
		nStart = mStart = 0;
		mEnd = nums2.Length - 1;
		nEnd = nums1.Length - 1;
		
		return FindMedian(nums1, nStart, nEnd, nums2, mStart, mEnd);
	}
	
	private double FindMedian(int[] N, int nStart, int nEnd, int[] M, int mStart, int mEnd)
	{
		int nLength = nEnd - nStart + 1;
		int mLength = mEnd - mStart + 1;
		
		if(nLength > mLength
			return FindMedian(M, mStart, mEnd, N, nStart, nEnd);
			
		// Case 0
		if(nLength <= 0)
			return M[FindMedianIndexOfOneArray(M, mStart, mEnd)];

		if (nLength == 1)
		{
			// Case 1: If larger array also has one element then return avg of two numbers
			if(mLength == 1)
				return (N[nStart] + M[mStart])/2.0;
			
			// Case 2: if Larger array has even number of elements			
			if (mLength % 2 != 0)
			{
				int medianIndex = (mStart + mEnd) / 2;
				double temp = GetMedianOf3Elements(M[medianIndex -1], M[medianIndex + 1], N[nStart]);
				return (temp + M[medianIndex]) / 2.0;
			}
			
			// Case 3 : Larger array has odd number of elements
			else
			{
				int median1 = (mStart + mEnd) / 2;
				int median2 = (mStart + mEnd + 1) / 2;
				return GetMedianOf3Elements(M[median1], M[median2], N[nStart]);
			}
		}

		if (nLength == 2)
		{
		}
		
		int mMedianIndex = FindMedianIndexOfOneArray(M, mStart, mEnd);
		int nMedianIndex = FindMedianIndexOfOneArray(N, nStart, nEnd);
		if (M[mMedianIndex] > N[nMedianIndex])
		{
			mEnd = mMedianIndex;
			nStart = nMedianIndex;
		}
		else
		{
			nEnd = nMedianIndex;
			mStart = mMedianIndex;
		}
		
		return FindMedian(N, nStart, nEnd, M, mStart, mEnd);
	}
}