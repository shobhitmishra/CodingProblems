<Query Kind="Program" />

void Main()
{
	TreeNode root = new TreeNode(3);
	root.left = new TreeNode(5);
	root.right = new TreeNode(1);
	root.left.left = new TreeNode(6);
	root.left.right = new TreeNode(2);
	root.right.left = new TreeNode(0);
	root.right.right = new TreeNode(8);
	root.left.right.left = new TreeNode(7);
	root.left.right.right = new TreeNode(4);
	var ob = new Solution();
	ob.LowestCommonAncestor(root, root, root.left.right.left).Dump();
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
	public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
	{
		var pathSoFar = new List<TreeNode>();
		
		var pPath = new List<TreeNode>();
		GetPathOfNode(root, p, pathSoFar, pPath);		
		//pPath.Dump();
		
		pathSoFar.Clear();
		
		var qPath = new List<TreeNode>();
		GetPathOfNode(root, q, pathSoFar, qPath);
		//qPath.Dump();
		
		if(pPath.Count() == 0 || qPath.Count() == 0)
			return null;
		
		int i = 0;
		while(i < pPath.Count() && i < qPath.Count() && pPath[i] == qPath[i])
			i++;
		i--;
		
		return pPath[i];
	}
	
	private void GetPathOfNode(TreeNode root, TreeNode node, List<TreeNode> pathSoFar, List<TreeNode> desiredPath)
	{
		if (root != null)
		{
			pathSoFar.Add(root);
			if (root == node)
			{
				desiredPath.AddRange(pathSoFar);	
				return;
			}	
			GetPathOfNode(root.left, node, pathSoFar, desiredPath);
			GetPathOfNode(root.right, node, pathSoFar, desiredPath);
			pathSoFar.Remove(root);
		}
	}
}