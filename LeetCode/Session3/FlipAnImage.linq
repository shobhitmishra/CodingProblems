<Query Kind="Program">
  <Namespace>static System.Linq.Enumerable</Namespace>
  <Namespace>System.IO</Namespace>
</Query>

void Main()
{
	var list1 = new int[] {1,1,0,0};
	var list2 = new int[] {1,0,0,1};
	var list3 = new int[] {0,1,1,1};
	var list4 = new int[] {1,0,1,0};
	var input = new int[][]{list1, list2, list3, list4};
	var ob = new Solution();
	ob.FlipAndInvertImage(input).Dump();
}

// Define other methods and classes here
public class Solution
{
	public int[][] FlipAndInvertImage(int[][] image)
	{
		return image.Select(x => x.Reverse().Select(y => y^1).ToArray()).ToArray();
	}	
}