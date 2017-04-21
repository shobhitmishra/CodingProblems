<Query Kind="Program" />

void Main()
{
	var head = new ListNode(1);
	var temp = head;
	for (int i = 2; i <= 8; i++)
	{
		temp.next = new ListNode(i);
		temp = temp.next;
	}
	var ob = new Solution();
	ob.PrintList(head);
	head = ob.ReverseBetween(head,1,3);
	Console.WriteLine();
	ob.PrintList(head);
}

// Define other methods and classes here
public class ListNode {
    public int val;
    public ListNode next;
    public ListNode(int x) { val = x; }
}

public class Solution
{
	public ListNode ReverseBetween(ListNode head, int m, int n)
	{
		if(m == n)
			return head;
		
		ListNode mPrev = null;
		var mNode = head;
		int count = 1;
		while (count < m)
		{
			mPrev = mNode;
			mNode = mNode.next;
			count++;
		}
		var prev = mPrev;
		var curr = mNode;
		var next = mNode.next;
		while (count <= n)
		{
			next = curr.next;
			curr.next = prev;
			prev = curr;
			curr = next;
			count++;
		}
		if(mPrev != null)
			mPrev.next = prev;
		else
			head = prev;
		mNode.next = curr;
		
		return head;
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
}