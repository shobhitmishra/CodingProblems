<Query Kind="Program" />

void Main()
{
	var input = new int[] { 3,5,0,3,4};
	var ob = new Solution();
	ob.Find132pattern(input).Dump();
}

// Define other methods and classes here
public class Solution
{
	public bool Find132pattern(int[] nums)
	{
		var smallestOnLeft = new int[nums.Length];
		
		var smallest = Int32.MaxValue;
		for (int i = 0; i < nums.Length; i++)
		{
			smallest = Math.Min(smallest, nums[i]);
			smallestOnLeft[i] = smallest;
		}
		
		// Now we need to find the maximum number on the right of this number.
		// We will maintain a stack which stores numbers on increasing order from start to end
		var stack = new Stack<int>();
		// start from right
		for (int i = nums.Length - 1; i >= 0 ; i--)
		{
			// push it if it is smaller than top
			if(stack.Count <= 0 || nums[i] <= stack.Peek())
				stack.Push(nums[i]);
			else
			{
				while (stack.Count > 0 && stack.Peek() < nums[i])
				{
					var poppedNum = stack.Pop();
					// if this number is bigger than smallest on its left then true
					if(poppedNum > smallestOnLeft[i])
						return true;
				}
				stack.Push(nums[i]);
			}
		}
		
		return false;
	}
}