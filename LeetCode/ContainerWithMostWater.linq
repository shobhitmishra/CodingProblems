<Query Kind="Program" />

void Main()
{
	var arr = new int[]{1,1};
	var ob = new Solution();
	ob.MaxArea(arr).Dump();
}

// Define other methods and classes here
public class Solution 
{
    public int MaxArea(int[] height) 
	{
        int start = 0;
		int end = height.Length -1;
		int result = 0;
		while(start < end)
		{
			int currentArea = (end - start) * Math.Min(height[start], height[end]);
			result = Math.Max(result, currentArea);
			if(height[end] < height[start])
				end--;
			else
				start++;
		}
		return result;
    }
}