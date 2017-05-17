<Query Kind="Program" />

void Main()
{
	var input = new int[] { 1, 1};
	var ob = new Solution();
	ob.LargestRectangleArea(input).Dump();
}

// Define other methods and classes here
public class Solution
{
	public int LargestRectangleArea(int[] heights)
	{
		if(heights.Length == 0)
			return 0;
		
		int max = 0;
		var smallerOnLeft = GetSmallerOnLeft(heights);
		var smallertOnRight = GetSmallerOnRight(heights);
		for (int i = 0; i < heights.Length; i++)
		{
			var maxAtCurrentPos = (smallertOnRight[i] - smallerOnLeft[i] - 1) * heights[i];
			max = Math.Max(max, maxAtCurrentPos);
		}
		return max;
	}
	
	private int[] GetSmallerOnLeft(int[] heights)
	{
		var result = new int[heights.Length];
		var stack = new Stack<int>();
		for (int i = 0; i < heights.Length; i++)
		{
			var currentNum = heights[i];
			// keep popping until there is a bigger number on top
			while (stack.Count > 0 && heights[stack.Peek()] >= currentNum)
			{
				stack.Pop();
			}
			var smallerOnLeft = stack.Count == 0 ? - 1 : stack.Peek();
			result[i] = smallerOnLeft;
			stack.Push(i);
		}
		return result;
	}

	private int[] GetSmallerOnRight(int[] heights)
	{
		var result = new int[heights.Length];
		var stack = new Stack<int>();
		for (int i = heights.Length - 1; i >= 0 ; i--)
		{
			var currentNum = heights[i];
			// keep popping until there is a bigger number on top
			while (stack.Count > 0 && heights[stack.Peek()] >= currentNum)
			{
				stack.Pop();
			}
			var smallerOnLeft = stack.Count == 0 ? heights.Length : stack.Peek();
			result[i] = smallerOnLeft;
			stack.Push(i);
		}
		return result;
	}
}