<Query Kind="Program" />

void Main()
{
	var ob = new Solution();
	var input = new int[] { 68, 82, 9, 97, 19, 27, 98, 99, 4};//, 30, 96};// 37, 9, 78, 43, 64, 4, 65};
	ob.WiggleMaxLength(input).Dump();
	ob.WiggleMaxLength2(input).Dump();
}

// Define other methods and classes here
public class Solution
{
	public int WiggleMaxLength(int[] nums)
	{
		var max = 0;
		if(nums.Length <= 1)
			return nums.Length;	

		var up = new int[nums.Length];
		var down = new int[nums.Length];
		up[0] = down[0] = 1;
		for (int i = 1; i < nums.Length; i++)
		{
			if (nums[i] > nums[i - 1])
			{
				up[i] = down[i-1] + 1;
				down[i] = down[i-1];
			}
			else if (nums[i] < nums[i - 1])
			{
				up[i] = up[i-1];
				down[i] = up[i-1] + 1;
			}
			else
			{
				up[i] = up[i-1];
				down[i] = down[i-1];
			}
			max = Math.Max(max, Math.Max(up[i], down[i]));
		}
		
		return max;;
	}
	
	// This gives wrong result. Run it with the example and you'll see why
	public int WiggleMaxLength2(int[] nums)
	{
		var max = 0;
		if (nums.Length <= 1)
			return nums.Length;
		var smallerOnLeft = GetSmallerOnLeft(nums);
		var biggerOnLeft = GetBiggerOnLeft(nums);

		var increasing = new int[nums.Length];
		var decreasing = new int[nums.Length];
		for (int i = 0; i < nums.Length; i++)
		{
			var smallerLeft = smallerOnLeft[i];
			increasing[i] = smallerLeft == -1 ? 1 : decreasing[smallerLeft] + 1;
			var biggerLeft = biggerOnLeft[i];
			decreasing[i] = biggerLeft == -1 ? 1 : increasing[biggerLeft] + 1;
			max = Math.Max(max, Math.Max(increasing[i], decreasing[i]));
		}

		return max; ;
	}

	private int[] GetSmallerOnLeft(int[] nums)
	{
		var result = new int[nums.Length];
		var stack = new Stack<int>();
		for (int i = 0; i < nums.Length; i++)
		{
			while (stack.Count > 0 && nums[stack.Peek()] >= nums[i])
				stack.Pop();
			result[i] = stack.Count == 0 ? -1 : stack.Peek();
			stack.Push(i);
		}
		return result;
	}

	private int[] GetBiggerOnLeft(int[] nums)
	{
		var result = new int[nums.Length];
		var stack = new Stack<int>();
		for (int i = 0; i < nums.Length; i++)
		{
			while (stack.Count > 0 && nums[stack.Peek()] <= nums[i])
				stack.Pop();
			result[i] = stack.Count == 0 ? -1 : stack.Peek();
			stack.Push(i);
		}
		return result;
	}
}