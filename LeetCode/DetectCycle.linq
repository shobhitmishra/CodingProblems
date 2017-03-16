<Query Kind="Program" />

void Main()
{
	var head = new ListNode(1);
	for (int i = 2; i <= 7; i++)
	{
		AddNodeToList(head, i);
	}
	var tail = GetTail(head);
	tail.next = head.next.next;
	
	var ob = new Solution();
	ob.DetectCycle(head).Dump();
}

// Define other methods and classes here
public void AddNodeToList(ListNode head, int value)
{
	var node = new ListNode(value);
	if (head == null)
		head = node;
	var headCopy = head;
	while (headCopy.next != null)
		headCopy = headCopy.next;
	headCopy.next = node;
}

public ListNode GetTail(ListNode head)
{	
	var headCopy = head;
	while (headCopy.next != null)
		headCopy = headCopy.next;
	return headCopy;
}

public void PrintList(ListNode head)
{
	var headCopy = head;
	while (headCopy != null)
	{
		Console.Write(headCopy.val + "\t");
		headCopy = headCopy.next;
	}
	Console.WriteLine();
}

public class ListNode
{
	public int val;
	public ListNode next;
	public ListNode(int x) { val = x; }
}
public class Solution
{
	public ListNode DetectCycle(ListNode head)
	{		
		ListNode fast = head;
		ListNode slow = head;
		while (true)
		{			
			if(fast == null || fast.next == null)
				return null;
			slow = slow.next;
			fast = fast.next.next;
			if (fast == slow)
			{
				var ptr1 = head;
				var ptr2 = fast;
				while (ptr1 != ptr2)
				{
					ptr1 = ptr1.next;
					ptr2 = ptr2.next;
				}
				return ptr1;
			}			
		}		
	}
}