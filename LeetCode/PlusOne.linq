<Query Kind="Program" />

void Main()
{
	var input = new int[] {0};
	var ob = new Solution();
	ob.PlusOne(input).Dump();
}

// Define other methods and classes here
public class Solution
{
	public int[] PlusOne(int[] digits)
	{
		var result = new Stack<int>();
		if(!IsValidInput(digits))
			return result.ToArray();	
		
		int cary = 1;
		for (int i = digits.Length -1; i >= 0 ; i--)
		{
			var newDigit = digits[i] + cary;
			result.Push(newDigit % 10);
			cary = newDigit / 10;
		}
		if(cary != 0)
			result.Push(cary);
		return result.ToArray();
	}

	public bool IsValidInput(int[] arr)
	{
		if(arr == null || arr.Length == 0)
			return false;
		return true;
	}	
}