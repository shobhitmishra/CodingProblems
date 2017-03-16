<Query Kind="Program" />

void Main()
{
	ListNode head = new ListNode(0);
	for (int i = 1; i < -1; i++)
	{
		head.AddNode(i);
	}
	head.PrintList();
	var ob = new Solution();
	var newhead = ob.ReverseList(head);
	newhead.PrintList();
}

// Define other methods and classes here
public class ListNode 
{
    public int val;
    public ListNode next;
	public ListNode(int x) { val = x; }
	public void AddNode(int value)
	{
		ListNode current = this;
		while(current.next != null)
			current = current.next;
		current.next = new ListNode(value);
	}
	public void PrintList()
	{
		ListNode current = this;
		while (current != null)
		{
			Console.Write("{0}\t", current.val);
			current = current.next;
		}
		Console.WriteLine();
	}
}

public class Solution
{
	ListNode newHead;
	public ListNode ReverseList(ListNode head)
	{
		if(head == null || head.next == null)
			return head;		
		ReverseListRecursive(head);
		head.next = null;
		return newHead;
	}

	public ListNode ReverseListRecursive(ListNode head)
	{
		if (head.next == null)
		{
			newHead = head;
			return head;
		}
		var next = ReverseListRecursive(head.next);
		next.next = head;
		return head;
	}
}