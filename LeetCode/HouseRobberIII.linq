<Query Kind="Program" />

void Main()
{
	
}

// Define other methods and classes here
public class TreeNode 
{
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int x) { val = x; }
}

public class Solution {
    public int Rob(TreeNode root) 
	{
        var result = DFS(root);
		return Math.Max(result[0], result[1]);
    }
	
	public int[] DFS(TreeNode root)
	{
		if(root == null)
			return new int[2];
		int[] result = new int[2];
		
		var left = DFS(root.left);
		var right = DFS(root.right);
		
		// First index stores the sum with the node value included
		result[0] = root.val + left[1] + right[1];
		
		// Second index stores the sum without root value.
		result[1] = Math.Max(left[0], left[1]) + Math.Max(right[0], right[1]);
		
		return result;
	}
}	
