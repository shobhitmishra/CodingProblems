<Query Kind="Program" />

void Main()
{
	int n = 11;
	var head = new ListNode(0);
	var tail = head;
	for (int i = 1; i <= n; i++)
	{
		tail.next = new ListNode(i);
		tail = tail.next;
	}
	head = head.next;
	PrintList(head);
	var ob = new Solution();
	head = ob.OddEvenList(head);
	PrintList(head);
}

public void PrintList(ListNode head)
{
	var temp = head;
	while (temp != null)
	{
		Console.Write(temp.val + "\t");
		temp = temp.next;
	}
	Console.WriteLine();
}
// Define other methods and classes here
public class ListNode {
    public int val;
    public ListNode next;
    public ListNode(int x) { val = x; }
}

public class Solution
{
	public ListNode OddEvenList(ListNode head)
	{
		if(head == null)
			return null;
		var odd = head; 
		var even = head.next;
		var evenHead = even;
		ListNode prev = null;
		
		while (odd != null || even != null)
		{
			if (odd != null)
			{
				prev = odd;
				odd.next = odd.next?.next;
			}
			if(even != null)
				even.next = even.next?.next;
			odd = odd?.next;
			even = even?.next;
		}
		prev.next = evenHead;
		return head;
	}
}