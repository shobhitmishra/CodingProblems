<Query Kind="Program" />

void Main()
{

}

// Define other methods and classes here
public class NestedInteger
{
	int? number;
	IList<NestedInteger> list;
	
	public NestedInteger(int num)
	{
		number = num;
	}
	
	public NestedInteger(List<NestedInteger> nums)
	{
		list = nums;
	}
	
	public bool IsInteger()
	{
		return number != null;
	}
	
	public int GetInteger()
	{
		return number.Value;
	}
	
	public IList<NestedInteger> GetList()
	{
		return list;
	}	
}

public class NestedIterator
{
	Stack<NestedInteger> stack = new Stack<NestedInteger>();
	public NestedIterator(IList<NestedInteger> nestedList)
	{
		for (int i = nestedList.Count -1; i >= 0 ; i--)
		{
			stack.Push(nestedList[i]);
		}
	}

	public bool HasNext()
	{
		while (stack.Count() > 0)
		{
			if(stack.Peek().IsInteger())
				return true;
			var list = stack.Pop().GetList();
			for (int i = list.Count -1; i >= 0 ; i--)
			{
				stack.Push(list[i]);
			}
		}
		return false;
	}

	public int Next()
	{
		return stack.Pop().GetInteger();
	}
}