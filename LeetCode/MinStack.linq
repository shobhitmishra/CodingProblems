<Query Kind="Program" />

void Main()
{
	
}

// Define other methods and classes here
public class MinStack
{
	Stack<int> stack = new Stack<int>();
	Stack<int> minStack = new Stack<int>();
	public void Push(int x)
	{
		stack.Push(x);
		if(minStack.Count == 0 || minStack.Peek() >= x)
			minStack.Push(x);	
			
	}

	public void Pop()
	{
		var x = stack.Pop();
		if(x <= minStack.Peek())
			minStack.Pop();
	}

	public int Top()
	{
		return stack.Peek();
	}

	public int GetMin()
	{
		return minStack.Peek();
	}
}