<Query Kind="Program" />

void Main()
{
	var l = new ListNode(-129);
	l.next = new ListNode(-129);
	var ob = new Solution();
	ob.IsPalindrome(l).Dump();
}


public class ListNode {
    public int val;
    public ListNode next;
    public ListNode(int x) { val = x; }
}

// Define other methods and classes here
public class Solution
{
	public bool IsPalindrome(ListNode head)
	{
		var l = new List<int>();
		while (head != null)
		{
			l.Add(head.val);
			head = head.next;
		}
		int i = 0;
		int j = l.Count - 1;
		while (i < j)
		{
			if(l[i] != l[j])
				return false;
			i++;
			j--;
		}		
		return true;
	}
}