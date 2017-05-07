<Query Kind="Program" />

void Main()
{
	var l1 = new ListNode(1);
	var l2 = new ListNode(2);
	for (int i = 3; i < 10; i = i + 2)
	{
		AddToList(i, l1);
	}
	for (int i = 4; i < 6; i = i + 2)
	{
		AddToList(i, l2);
	}
	PrintList(l1);
	PrintList(l2);
	var ob = new Solution();
	var h = ob.MergeTwoLists(null, l2);
	PrintList(h);
}

// Define other methods and classes here
public class ListNode {
    public int val;
    public ListNode next;
    public ListNode(int x) { val = x; }
}

public void AddToList(int val, ListNode head)
{
	var dummy = head;
	while(dummy.next != null)
		dummy = dummy.next;
	dummy.next = new ListNode(val);
}

public void PrintList(ListNode head)
{
	var dummy = head;
	while (dummy != null)
	{
		Console.Write(dummy.val + "\t");
		dummy = dummy.next;
	}
	Console.WriteLine();
}

public class Solution
{
	public ListNode MergeTwoLists(ListNode l1, ListNode l2)
	{
		var dummyHead = new ListNode(0);
		var tail = dummyHead;
		while (l1 != null || l2 != null)
		{
			int x = l1 != null ? l1.val : Int32.MaxValue;
			int y = l2 != null ? l2.val : Int32.MaxValue;

			if (x < y)
			{
				tail.next = l1;
				l1 = l1.next;
			}
			else
			{
				tail.next = l2;
				l2 = l2.next;
			}
			tail = tail.next;
		}
		return dummyHead.next;
	}
}
