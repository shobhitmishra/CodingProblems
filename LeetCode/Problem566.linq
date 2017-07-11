<Query Kind="Program" />

void Main()
{
	var input = new int[,] { {1,2,3}, {4,5,6}};
	var ob = new Solution();
	ob.MatrixReshape(input, 1, 6).Dump();
}

// Define other methods and classes here
public class Solution
{
	public int[,] MatrixReshape(int[,] nums, int r, int c)
	{
		var rows = nums.GetLength(0);
		var cols = nums.GetLength(1);
		
		if(rows * cols != r * c)
			return nums;
		
		var result = new int[r,c];
		for (int i = 0; i < rows * cols; i++)
		{
			result[i/c, i%c] = nums[i/cols, i%cols];
		}
		return result;
	}
}