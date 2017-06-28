<Query Kind="Program" />

void Main()
{
	var head = new ListNode(1);
	for (int i = 2; i < 11; i++)
	{
		AddToList(head,i);
	}
	PrintList(head);
	Console.WriteLine();
	var ob = new Solution();
	var newHead = ob.ReverseBetween(head,4,10);
	PrintList(newHead);
}

// Define other methods and classes here
public class ListNode
{
	public int val;
	public ListNode next;
	public ListNode(int x) { val = x; }
}

public void AddToList(ListNode head, int val)
{
	var temp = head;
	while(temp.next != null)
		temp = temp.next;
	temp.next = new ListNode(val);
}

public void PrintList(ListNode head)
{
	if (head != null)
	{
		Console.Write(head.val);
		Console.Write("\t");
		PrintList(head.next);
	}	
}


public class Solution
{
	public ListNode ReverseBetween(ListNode head, int m, int n)
	{
		var dummy = new ListNode(0);
		dummy.next = head;
		
		var mPrev = dummy;
		var mNode = head;
		for (int i = 1; i < m; i++)
		{
			mPrev = mNode;
			mNode = mNode.next;
		}
		
		var nNode = head;
		for (int i = 1; i < n; i++)
		{
			nNode = nNode.next;
		}
		var nNext = nNode.next;
		
		var prev = mPrev;
		var current = mNode;
		while (current != nNext)
		{
			var next = current.next;
			current.next = prev;
			prev = current;
			current = next;
		}
		
		mPrev.next = nNode;
		mNode.next = nNext;
		
		return dummy.next;
	}
}