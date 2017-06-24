<Query Kind="Program" />

void Main()
{
	var ob = new Solution();
	var input = 18;
	ob.ConstructRectangle(input).Dump();
}

// Define other methods and classes here
public class Solution
{
	public int[] ConstructRectangle(int area)
	{
		int width = (int)Math.Sqrt(area);
		while(area % width != 0)
			width--;
		return new int[] { area / width, width};		
	}
}