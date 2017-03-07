<Query Kind="Program" />

void Main()
{
	var root = new TreeNode(2);
	root.right = new TreeNode(3);
	root.right.left = new TreeNode(2);
	root.right.right = new TreeNode(4);
	root.right.right.right = new TreeNode(5);
	var ob = new Solution();
	ob.LongestConsecutive(root).Dump();
}

// Define other methods and classes here
public class TreeNode {
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int x) { val = x; }
}

public class Solution {
    public int LongestConsecutive(TreeNode root) 
	{
    	if(root == null)
			return 0;
		int longestLength = 0;	
		LongestConsecutiveHelper(root, null, 0, ref longestLength);
		return longestLength;
    }
	public void LongestConsecutiveHelper(TreeNode current, TreeNode prev, int prevHeight, ref int longestLength)
	{
		if(current != null)
		{
			int currentHeight = 1;
			if(prev != null && current.val - prev.val == 1)
				currentHeight = prevHeight + 1;		
			longestLength = Math.Max(longestLength, currentHeight);
			LongestConsecutiveHelper(current.left, current, currentHeight, ref longestLength);
			LongestConsecutiveHelper(current.right, current, currentHeight, ref longestLength);
		}
	}
}