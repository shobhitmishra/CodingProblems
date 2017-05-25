<Query Kind="Program" />

void Main()
{
	var ob = new Solution();
	for (int i = 1; i <= 10; i++)
	{
		// create and populate the list
		var head = new ListNode(1);
		for(int j = 2; j <= 10; j++)
			AddToList(head, j);
		
		Console.WriteLine("Orginal List");
		PrintList(head);
		Console.WriteLine($"Removing {i}th Node");
		Console.WriteLine("ListAfter Removing");
		head = ob.RemoveNthFromEnd2(head,i);
		PrintList(head);
		Console.WriteLine("------------");
	}
}

// Define other methods and classes here
public class ListNode {
    public int val;
    public ListNode next;
    public ListNode(int x) { val = x; }
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

public void AddToList(ListNode head, int val)
{
	var node = new ListNode(val);
	var temp = head;
	while (temp.next != null)
	{
		temp = temp.next;
	}
	temp.next = node;
}
 
public class Solution
{
	public ListNode RemoveNthFromEnd(ListNode head, int n)
	{
		if(head == null)
			return null;
		// get the nthnode and prev node
		ListNode prev = null;
		var nthNode = head;
		var fastNode = head;
		while (n > 0)
		{
			fastNode = fastNode.next;
			n--;
		}

		while (fastNode != null)
		{
			prev = nthNode;
			nthNode = nthNode.next;
			fastNode = fastNode.next;
		}
		// special case if we are deleting head;
		if(nthNode == head)
			return nthNode.next;
		prev.next = nthNode.next;
		return head;
	}
	
	public ListNode RemoveNthFromEnd2(ListNode head, int n)
	{
		if (head == null)
			return null;
		
		var dummy = new ListNode(0);
		dummy.next = head;

		var fastNode = head;		
		while (n > 0)
		{
			fastNode = fastNode.next;
			n--;
		}

		while (fastNode != null)
		{
			dummy = dummy.next;
			fastNode = fastNode.next;
		}
		
		if(dummy.next == head)
			return head.next;
		
		dummy.next = dummy.next.next;
		return head;
	}
}