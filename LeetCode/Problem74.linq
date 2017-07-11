<Query Kind="Program" />

void Main()
{
	var input = new int[,] { {1,3,5,7}, {10,11,16,20}, {23,30,34,50}};
	var ob = new Solution();
	ob.SearchMatrix(input, 17).Dump();
}

// Define other methods and classes here
public class Solution
{
	public bool SearchMatrix(int[,] matrix, int target)
	{
		int rows = matrix.GetLength(0);
		int cols = matrix.GetLength(1);
		int low = 0;
		int high = rows * cols - 1;

		while (low <= high)
		{
			int mid = (low + high) / 2;
			
			var twoDIndex = Get2DIndex(mid, cols);
			var i = twoDIndex[0];
			var j = twoDIndex[1];
			var val = matrix[i,j];
			
			if(target == val)
				return true;
			if(target < val)
				high = mid -1;
			else
				low = mid + 1;			
		}	
		return false;
	}
	
	private int[] Get2DIndex(int oneDimensionIndex, int cols)
	{
		return new int[2] { oneDimensionIndex / cols, oneDimensionIndex % cols};
	}	
	
}