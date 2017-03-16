<Query Kind="Program" />

void Main()
{
	var l1 = new ListNode(2);
	var l2 = new ListNode(5);
	AddValToList(l1,4);
	AddValToList(l1,3);
	AddValToList(l2,6);
	AddValToList(l2,4);
	PrintList(l1);
	PrintList(l2);
	var ob = new Solution();
	var l3 = ob.AddTwoNumbers(null,null);
	PrintList(l3);
}

// Define other methods and classes here
public class ListNode {
    public int val;
    public ListNode next;
    public ListNode(int x) { val = x; }
}

public void AddValToList(ListNode head, int val)
{
	var temp = new ListNode(val);
	var headCopy = head;
	while(headCopy.next != null)
		headCopy = headCopy.next;
	headCopy.next = temp;
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

public class Solution
{
	public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
	{
		var dummy = new ListNode(0);
		var l3 = dummy;
		int carry = 0;
		while (l1 != null && l2 != null)
		{
			int result = l1.val + l2.val + carry;
			l3.next = new ListNode(result % 10);
			l1 = l1.next;
			l2 = l2.next;
			l3 = l3.next;
			carry = result / 10;
		}		
		if(l1 == null)
			Copy(l2,l3,carry);
		if(l2 == null)
			Copy(l1,l3,carry);
		return dummy.next;
	}

	public void Copy(ListNode src, ListNode dest, int carry)
	{
		while (src != null)
		{
			int result = src.val + carry;
			dest.next = new ListNode(result % 10);
			src = src.next;
			dest = dest.next;
			carry = result / 10;
		}
		if(carry > 0)
			dest.next = new ListNode(carry);
	}
}