<Query Kind="Program" />

void Main()
{
	var ob = new Stack();
	for (int i = 1; i <= 10; i++)
	{
		ob.Push(i);
		if (i % 3 == 0)
			ob.Pop();
		ob.Top().Dump();		
	}
}

// Define other methods and classes here
public class Stack 
{
	Queue<int> inQ = new Queue<int>();
	Queue<int> outQ = new Queue<int>();
    // Push element x onto stack.
    public void Push(int x) 
	{
		// take the input in the inQ and copy other elements
		inQ.Enqueue(x);
		while (outQ.Count > 0)
		{
			int element = outQ.Dequeue();
			inQ.Enqueue(element);
		}
		// swap the queueus
		var temp = inQ;
		inQ = outQ;
		outQ = temp;
    }

    // Removes the element on top of the stack.
    public void Pop() 
	{
        outQ.Dequeue();
    }

    // Get the top element.
    public int Top() 
	{
        return outQ.Peek();
    }

	// Return whether the stack is empty.
	public bool Empty()
	{
		return outQ.Count == 0;
	}
}