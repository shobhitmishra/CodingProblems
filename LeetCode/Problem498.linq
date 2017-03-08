<Query Kind="Program" />

/*
Given a matrix of M x N elements (M rows, N columns), return all elements of the matrix in diagonal order as shown in the below image.

Example:
Input:
[
 [ 1, 2, 3 ],
 [ 4, 5, 6 ],
 [ 7, 8, 9 ]
]
Output:  [1,2,4,7,5,3,6,8,9]
Explanation (https://leetcode.com/problems/diagonal-traverse/?tab=Description): 
*/
void Main()
{
	//var input = new int[,] {{1,2,3,4,5},{6,7,8,9,10},{11, 12, 13, 14, 15}, {16, 17, 18, 19, 20}};
	var input = new int[,] {{1,2}};
	var ob = new Solution();
	ob.FindDiagonalOrder(input).Dump();
}

// Define other methods and classes here
public class Solution 
{
    public int[] FindDiagonalOrder(int[,] matrix) 
	{
        bool directionUp = true;
		int i = 0;
		int j = 0;
		int iBoundary = matrix.GetLength(0) - 1;
		int jBoundary = matrix.GetLength(1) - 1;
		List<int> orderedElements = new List<int>();
		if(iBoundary < 0 || jBoundary < 0)
			return orderedElements.ToArray();
		
		while(true)
		{
			orderedElements.Add(matrix[i,j]);
			if(i == iBoundary && j == jBoundary)
			// reached to the last element
				break;
			GetNextIndex(ref i, ref j, ref directionUp, iBoundary, jBoundary);
		}
		
		return orderedElements.ToArray();
    }
	
	private void GetNextIndex(ref int i, ref int j, ref bool directionUp, int iBoundary, int jBoundary)
	{		
		int iNext, jNext;
		if(directionUp)
		{
			iNext = i -1;
			jNext = j + 1;
			if(IsBeyondBoundary(iNext, jNext, iBoundary, jBoundary))
			{
				// try to go right
				if(j + 1 <= jBoundary)
				{
					iNext = i;
					jNext = j + 1;					
				}
				// go down if can't go right
				else
				{
					iNext = i + 1;
					jNext = j;
				}
				directionUp = !(directionUp);
			}
		}
		else
		{
			iNext = i + 1;
			jNext = j - 1;
			if(IsBeyondBoundary(iNext, jNext, iBoundary, jBoundary))
			{
				// try to go down
				if(i + 1 <= iBoundary)
				{
					iNext = i + 1;
					jNext = j;
				}
				// go right if can't go down
				else
				{
					iNext = i;
					jNext = j + 1;
				}
				directionUp = !(directionUp);
			}
		}
		
		i = iNext;
		j = jNext;
	}
	
	private bool IsBeyondBoundary(int i, int j, int iBoundary, int jBoundary)
	{		
		if(i < 0 || i > iBoundary || j < 0 || j > jBoundary)
			return true;
		return false;
	}
}