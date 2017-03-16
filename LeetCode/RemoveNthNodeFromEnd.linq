<Query Kind="Program" />

void Main()
{
	var l = new ListNode(1);
//	for (int i = 2; i <= 10; i++)
//	{
//		AddToList(l, i);
//	}
	PrintList(l);
	
	var ob = new Solution();
	var removePosition = 1;
	l = ob.RemoveNthFromEnd(l, removePosition);
	PrintList(l);
}

public void PrintList(ListNode head)
{
	var copy = head;
	while (copy != null)
	{
		Console.Write(copy.val + "\t");
		copy = copy.next;
	}
	Console.WriteLine();
}

public void AddToList(ListNode head, int val)
{
	var temp = new ListNode(val);
	var copy = head;
	while (copy.next != null)	
		copy = copy.next;
	copy.next = temp;
}

// Define other methods and classes here
public class ListNode 
{
    public int val;
    public ListNode next;
    public ListNode(int x) { val = x; }
}

public class Solution
{
	public ListNode RemoveNthFromEnd(ListNode head, int n)
	{
		ListNode first = head;
		ListNode second = head;
		ListNode prev = null;
		for (int i = 0; i < n; i++)
		{
			second = second.next;
		}
		while (second != null)
		{
			prev = first;
			first = first.next;
			second = second.next;
		}
		if (first.next == null)
		{
			if (prev == null)
				return null;
			prev.next = null;
		}
		else
		{
			first.val = first.next.val;
			first.next = first.next.next;
		}
		return head;
	}
}