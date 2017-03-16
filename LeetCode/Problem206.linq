<Query Kind="Program" />

// Reverse a singly linked list.
void Main()
{
	var ll = new ListNode(1);
	for (int i = 2; i <= 22; i++)
	{
		//AddANodeToLLIteratirve(ll, i);
		AddANodeToListRecursive(ll,i);
	}
	PrintALLRecursive(ll);
	Console.WriteLine ("Jai bheem");
	var ob = new Solution();
	var newhead = ob.ReverseListRecursively(ll);
	PrintALLRecursive(newhead);
}

// Define other methods and classes here
public class ListNode 
{
    public int val;
    public ListNode next;
    public ListNode(int x) { val = x; }
}

public void AddANodeToLLIteratirve(ListNode head, int value)
{
	ListNode temp = head;
	while(temp.next != null)
		temp = temp.next;
	temp.next = CreateNode(value);
}

public ListNode AddANodeToListRecursive(ListNode head, int value)
{
	if(head == null)
		return CreateNode(value);
	
	head.next = AddANodeToListRecursive(head.next, value);
	return head;
}

public ListNode CreateNode(int value)
{
	return new ListNode(value);
}

public void PrintALLRecursive(ListNode head)
{
	if(head != null)
	{
		Console.WriteLine (head.val);
		PrintALLRecursive(head.next);		
	}
}

public class Solution 
{
	ListNode newHead;
    public ListNode ReverseList(ListNode head) 
	{
		if(head == null || head.next == null)
			return head;
		
        ListNode prev = null, next;
		ListNode curr = head;
		while(curr != null)
		{
			next = curr.next;
			curr.next = prev;
			prev = curr;
			curr = next;
		}
		return prev;
    }
	
	public ListNode ReverseListRecursively(ListNode head)
	{
		ReverseListRecursivelyHelper(head);
		head.next = null;
		return newHead;
	}
	
	public ListNode ReverseListRecursivelyHelper(ListNode head)
	{
		if(head.next == null)
		{
			newHead = head;
			return head;
		}
		var next = ReverseListRecursivelyHelper(head.next);
		next.next = head;
		return head;
	}
}