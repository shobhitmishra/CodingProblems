<Query Kind="Program" />

void Main()
{
	var arr = new int[] {0,1,0,2,1,0,1,3,2,1,2,1};
	var ob = new Solution();
	ob.Trap(arr).Dump();
}

// Define other methods and classes here
public class Solution 
{
	public int Trap(int[] height) 
	{
		int left = 0;
		int right = height.Length - 1;
		int biggestInLeft = 0;
		int biggestInRight = 0;
		int trap = 0;
		while(left < right)
		{
			if(height[left] <= height[right])
			{
				if(biggestInLeft < height[left]) biggestInLeft = height[left];
				trap += biggestInLeft - height[left];
				left++;
			}
			else
			{
				if(biggestInRight < height[right]) biggestInRight = height[right];
				trap += biggestInRight - height[right];
				right--;
			}
		}
		return trap;
	}
	
    public int Trap1(int[] height) 
	{
    	int biggestInLeft = 0;
		int biggestInRight = 0;
		int trap = 0;
		int[] left = new int[height.Length];
		int[] right = new int[height.Length];
		for (int i = 0; i < height.Length; i++)
		{
			biggestInLeft = Math.Max(biggestInLeft,height[i]);
			left[i] = biggestInLeft;
		}
		for (int i = height.Length -1; i >= 0 ; i--)
		{
			biggestInRight = Math.Max(biggestInRight, height[i]);
			right[i] = biggestInRight;
		}
		for (int i = 0; i < height.Length; i++)
		{
			trap += Math.Min(left[i], right[i]) - height[i];
		}
		return trap;
    }
}