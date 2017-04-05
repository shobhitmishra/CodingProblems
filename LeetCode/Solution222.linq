<Query Kind="Program" />

void Main()
{
	var root = new TreeNode(1);
	root.left = new TreeNode(2);
	root.right = new TreeNode(3);
	root.left.left = new TreeNode(4);
	root.left.right = new TreeNode(5);
	//root.right.left = new TreeNode(6);
	var ob = new Solution();
	ob.CountNodes(root).Dump();
}

// Define other methods and classes here
public class TreeNode
{
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int x) { val = x; }
}
public class Solution
{
	// The main observation to solve this problem is that if the tree is completely full
	// then height of left subtree and rightr subtree will be the same and you can  
	// calcualte the number of nodes in O(1)
	public int CountNodes(TreeNode root) 
	{
        if(root == null)
			return 0;
		
		int leftTreeHeight = 0;
		int rightTreeHeight = 0;
		var left = root.left;
		var right = root.right;
		
		while (left != null)
		{
			left = left.left;
			leftTreeHeight++;
		}
		while (right != null)
		{
			right = right.right;
			rightTreeHeight++;
		}
		
		if(leftTreeHeight == rightTreeHeight)
			return (1 << (leftTreeHeight + 1)) - 1;
			
		return 1 + CountNodes(root.left) + CountNodes(root.right);		
    }
	
}
