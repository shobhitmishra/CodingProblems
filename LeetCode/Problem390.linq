<Query Kind="Program" />

void Main()
{
	var ob = new Solution();
	ob.LastRemaining(25).Dump();
}

// Define other methods and classes here
public class Solution
{
	public int LastRemaining(int n)
	{
		int step = 1;
		int head = 1;
		int remaining = n;
		bool goingLeft = true;		
		while (remaining > 1)
		{
			if (goingLeft || remaining % 2 == 1)
			{
				head += step;				 
			}			
			remaining = remaining / 2;
			step *= 2;
			goingLeft = !goingLeft;
		}
		return head;
	}
}