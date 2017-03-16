<Query Kind="Program" />

void Main()
{
	var head = new ListNode(1);
	AddNodeToList(head, 4);
	AddNodeToList(head, 3);
	AddNodeToList(head, 2);
	AddNodeToList(head, 5);
	AddNodeToList(head, 2);
	PrintList(head);
	var ob = new Solution();
	var newList = ob.Partition(head, 3);
	PrintList(newList);
}

// Define other methods and classes here
public void AddNodeToList(ListNode head, int value)
{
	var node = new ListNode(value);
	if(head == null)
		head = node;
	var headCopy = head;
	while(headCopy.next != null)
		headCopy = headCopy.next;
	headCopy.next = node;
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
	public ListNode Partition(ListNode head, int x)
	{
		if(head == null)
			return null;
		var lessThanX = new ListNode(-Int32.MaxValue);
		var moreThanX = new ListNode(Int32.MaxValue);
		var lessThanXhead = lessThanX;
		var moreThanXhead = moreThanX;		
		var headCopy = head;
		while (headCopy != null)
		{			
			if (headCopy.val < x)
			{
				lessThanX.next = headCopy;
				lessThanX = lessThanX.next;
			}
			else
			{
				moreThanX.next = headCopy;
				moreThanX = moreThanX.next;
			}
			headCopy = headCopy.next;			
		}		
		lessThanX.next = moreThanXhead.next;
		moreThanX.next = null;
		return lessThanXhead.next;
	}
}