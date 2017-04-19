<Query Kind="Program" />

void Main()
{
	var ob = new Solution();
	var nums1 = new int[] { 1, 1, 3, 3};
	var nums2 = new int[] { 1, 1, 3, 3};
	ob.FindMedianSortedArrays(nums1, nums2).Dump();
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

	private double FindMedianOfOneArray(int[] arr, int start, int end)
	{
		int length = end - start + 1;
		if(length == 0)
			throw new ArgumentOutOfRangeException("Array of zero size");
		// Odd legth array
		if(length % 2 != 0)
			return (double)arr[(start + end) / 2];
		int median1 = (start + end) / 2;
		int median2 = (start + end + 1) / 2;
		
		return (arr[median1] + arr[median2])/2.0;
	}
	
	private double GetMedianOf3Elements(int a, int b, int c)
	{
		return (double)(a + b + c - Math.Max(a,Math.Max(b,c)) - Math.Min(a,Math.Min(b,c)));
	}
	
	private double GetMedianOf4Elements(int a, int b, int c, int d)
	{
		int max = Math.Max(a, Math.Max(b, Math.Max(c,d)));
		int min = Math.Min(a, Math.Min(b, Math.Min(c,d)));
		return (a + b + c + d - max - min) /2.0;
	}
	
	private double FindMedian(int[] N, int nStart, int nEnd, int[] M, int mStart, int mEnd)
	{
		int nLength = nEnd - nStart + 1;
		int mLength = mEnd - mStart + 1;
		
		if(nLength > mLength)
			return FindMedian(M, mStart, mEnd, N, nStart, nEnd);
			
		// Case 0
		if(nLength <= 0)
			return FindMedianOfOneArray(M, mStart, mEnd);

		if (nLength == 1)
		{
			// Case 1: If larger array also has one element then return avg of two numbers
			if(mLength == 1)
				return (N[nStart] + M[mStart])/2.0;
			
			// Case 2: if Larger array has odd number of elements			
			if (mLength % 2 != 0)
			{
				int medianIndex = (mStart + mEnd) / 2;
				double temp = GetMedianOf3Elements(M[medianIndex -1], M[medianIndex + 1], N[nStart]);
				return (temp + M[medianIndex]) / 2.0;
			}
			
			// Case 3 : Larger array has even number of elements
			else
			{
				int median1 = (mStart + mEnd) / 2;
				int median2 = (mStart + mEnd + 1) / 2;
				return GetMedianOf3Elements(M[median1], M[median2], N[nStart]);
			}
		}

		if (nLength == 2)
		{
			// case 4: both the arrays have only 2 elements
			if(mLength == 2)
				return GetMedianOf4Elements(N[nStart], N[nEnd], M[mStart], M[mEnd]);

			// case 5: if Larger array has odd number of elements
			if (mLength % 2 != 0)
			{
				int medianIndex = (mStart + mEnd) / 2;
				return GetMedianOf3Elements(M[medianIndex], Math.Max(M[medianIndex -1], N[nStart]),
					Math.Min(M[medianIndex +1], N[nEnd]));
			}

			// case 6: if Larger Array has odd number of elements
			else
			{
				int median1 = (mStart + mEnd) / 2;
				int median2 = (mStart + mEnd + 1) / 2;
				return GetMedianOf4Elements(M[median1], M[median2], 
					Math.Max(M[median1 -1], N[nStart]), Math.Min(M[median2 + 1], N[nEnd]));
			}
		}

		int mMedianIndex = (mStart + mEnd) / 2;
		int nMedianIndex = (nStart + nEnd) / 2;
		int newLengthOfN = nLength / 2 + 1;
		int itemsToBeRemoved = nLength - newLengthOfN;
		
		if (N[nMedianIndex] <= M[mMedianIndex])
		{			
			mEnd -= itemsToBeRemoved;
			nStart += itemsToBeRemoved;
		}
		else if(N[nMedianIndex] > M[mMedianIndex])
		{			
			nEnd -= itemsToBeRemoved;
			mStart += itemsToBeRemoved;
		}	
		
		return FindMedian(N, nStart, nEnd, M, mStart, mEnd);
	}
}