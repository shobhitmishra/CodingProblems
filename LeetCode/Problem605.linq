<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.IO.dll</Reference>
</Query>

void Main()
{
	var input = new int[] { 1, 0, 0, 0, 0, 1};
	var ob = new Solution();
	ob.CanPlaceFlowers(input,2).Dump();
}

// Define other methods and classes here
public class Solution
{
	public bool CanPlaceFlowers(int[] flowerbed, int n)
	{
		for (int i = 0; i < flowerbed.Length; i++)
		{
			if (flowerbed[i] == 0)
			{
				int left = i > 0 ? flowerbed[i-1] : 0;
				int right = i < flowerbed.Length - 1 ? flowerbed[i + 1] : 0;
				if (left == 0 && right == 0)
				{
					flowerbed[i] = 1;
					n--;
				}
			}
		}
		return n <= 0;
	}
}