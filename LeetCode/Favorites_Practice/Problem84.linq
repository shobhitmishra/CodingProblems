<Query Kind="Program" />

void Main()
{
	var ob = new Solution();
	var input = new int[] {1,1};
	ob.LargestRectangleArea(input).Dump();
}

// Define other methods and classes here
public class Solution
{
	public int LargestRectangleArea(int[] heights)
	{
		var smallerOnLeft = GetNextSmallerOnLeft(heights);
		var smallerOnRight = GetSmallerOnRight(heights);	
		var maxArea = 0;
		for (int i = 0; i < heights.Length; i++)
		{
			var currArea = (smallerOnRight[i] - smallerOnLeft[i] - 1) * heights[i];
			maxArea = Math.Max(maxArea, currArea);
		}
		return maxArea;
	}
	
	private int[] GetNextSmallerOnLeft(int[] heights)
	{
		var smallerOnLeft = new int[heights.Length];
		var stack = new Stack<int>();
		for (int i = 0; i < heights.Length; i++)
		{
			while(stack.Count > 0 && heights[stack.Peek()] >= heights[i])
				stack.Pop();
			
			smallerOnLeft[i] = stack.Count() == 0 ? -1 : stack.Peek(); 
			stack.Push(i);
		}
		return smallerOnLeft;
	}
	
	private int[] GetSmallerOnRight(int[] heights)
	{
		var smallerOnRight = new int[heights.Length];
		var stack = new Stack<int>();
		for (int i = heights.Length - 1; i >= 0 ; i--)
		{
			while (stack.Count > 0 && heights[stack.Peek()] >= heights[i])
				stack.Pop();
			
			smallerOnRight[i] = stack.Count() == 0 ? heights.Length : stack.Peek();
			stack.Push(i);
		}		
		return smallerOnRight;
	}
}