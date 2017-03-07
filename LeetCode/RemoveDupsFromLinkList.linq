<Query Kind="Program" />

void Main()
{
	ListNode head = new ListNode(1);
	AddToList(1, head);
	AddToList(2, head);
	AddToList(2, head);
	AddToList(2, head);
	AddToList(3, head);
	AddToList(4, head);
	AddToList(5, head);
	AddToList(6, head);
	AddToList(7, head);
	PrintList(head);
	PrintList(head);
	var ob = new Solution();
	ob.DeleteDuplicates(head);
	PrintList(head);
}

// Define other methods and classes here
public class ListNode 
{
    public int val;
    public ListNode next;
    public ListNode(int x) { val = x; }
}
public void PrintList(ListNode node)
{
	var temp = node;
	while(temp != null)
	{
		Console.Write(temp.val + "\t");
		temp = temp.next;
	}
	Console.WriteLine();
}

public void AddToList(int number, ListNode node)
{
	var newNode = new ListNode(number);
	var temp = node;
	while(temp.next != null)
	{		
		temp = temp.next;
	}
	temp.next = newNode;
}
public class Solution 
{
    public ListNode DeleteDuplicates(ListNode head) 
	{        
		if(head == null || head.next == null)
			return head;
		
		var newHead = head;
		var current = head.next;
		var prev = head;
		
		while(current != null)
		{
			if(current.val != prev.val)
			{
				newHead.next = current;
				newHead = current;
			}
			prev = current;
			current = current.next;
		}
		newHead.next = null;
		return head;
    }
}