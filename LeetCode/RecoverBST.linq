<Query Kind="Program" />

void Main()
{
	TreeNode root = new TreeNode(0);
	root.left = new TreeNode(1);
	var ob = new Solution();
	ob.RecoverTree(root);
}

// Define other methods and classes here
public class TreeNode {
	public int val;
	public TreeNode left;
	public TreeNode right;
	public TreeNode(int x) { val = x; }
}
 
public class Solution {
	TreeNode first, middle, last, previous;
    public void RecoverTree(TreeNode root) 
	{        
		FindOutOfOrderNodes(root);
		if(last != null)
			SwapNodeValues(first, last);
		else if(first != null)
			SwapNodeValues(first, middle);
    }
	private void SwapNodeValues(TreeNode node1, TreeNode node2)
	{
		int temp = node1.val;
		node1.val = node2.val;
		node2.val = temp;
	}
	private void FindOutOfOrderNodes(TreeNode root)
	{
		if(root != null)
		{
			FindOutOfOrderNodes(root.left);
			if(previous != null)
			{
				if(previous.val > root.val)
				{
					if(first == null)
					{
						first = previous;
						middle = root;
					}
					else
						last = root;
				}
			}			
			previous = root;
			FindOutOfOrderNodes(root.right);
		}
	}
}