<Query Kind="Program" />

void Main()
{
	var l1 = new ListNode(1);
	l1.next = new ListNode(4);
	l1.next.next = new ListNode(5);

	var l2 = new ListNode(1);
	l2.next = new ListNode(3);
	l2.next.next = new ListNode(4);

	var l3 = new ListNode(2);
	l3.next = new ListNode(6);
	
	var kLists = new ListNode[] {l1, l2, l3};
	var ob = new Solution();
	//ob.MergeKLists(kLists).Dump();
	ob.MergeKLists(new ListNode[] {}).Dump();
}

// Define other methods and classes here
public class ListNode
{
    public int val;
    public ListNode next;
    public ListNode(int x) { val = x; }
}

public class Solution
{
	public ListNode MergeKLists(ListNode[] lists)
	{
		if(lists.Length == 0)
			return null;
		var linkLists = new List<ListNode>(lists);
		while(linkLists.Count() > 1)
		{
			var tempList = new List<ListNode>();
			for (int i = 0; i < linkLists.Count() - 1; i +=2)
			{
				// merge i and i + 1
				var mergedList = MergeTwoLists(linkLists[i], linkLists[i+1]);
				tempList.Add(mergedList);
			}
			if(linkLists.Count() % 2 != 0)
			{
				tempList.Add(linkLists[linkLists.Count() - 1]);	
			}
			
			linkLists = tempList;
		}
		return linkLists[0];
	}
	
	private ListNode MergeTwoLists(ListNode l1, ListNode l2)
	{
		var dummy = new ListNode(0);
		var head = dummy;
		while(l1 != null && l2 != null)
		{
			if(l1.val < l2.val)
			{
				head.next = l1;
				l1 = l1.next;
			}
			else
			{
				head.next = l2;
				l2 = l2.next;
			}
			head = head.next;
		}
		if(l1 == null)
			head.next = l2;
		else
			head.next = l1;
			
		return dummy.next;
	}
}