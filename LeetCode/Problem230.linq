<Query Kind="Program" />

void Main()
{
	TreeNode root = new TreeNode(16);
	root.left = new TreeNode(8);
	root.left.left = new TreeNode(4);
	root.left.left.left = new TreeNode(3);
	root.left.left.left.left = new TreeNode(2);
	root.left.left.left.left.left = new TreeNode(1);
	
	root.left.right = new TreeNode(12);
	
	root.right = new TreeNode(40);
	root.right.left = new TreeNode(20);
	root.right.left.left = new TreeNode(18);
	root.right.left.right = new TreeNode(30);
	
	root.right.right = new TreeNode(50);
	root.right.right.right = new TreeNode(60);
	root.right.right.right.right = new TreeNode(70);
	
//	var l = new List<int>();
//	InOrderTraversal(root, l);
//	l.Dump();
//	Console.WriteLine();
//	
//	for (int i = 1; i <=14; i++)
//	{
//		var ob = new Solution();
//		ob.KthSmallest(root,i).Dump();
//	}

	var ob = new Solution();
	ob.IsBalanced(root.left).Dump();
	
}

// Define other methods and classes here
public class TreeNode {
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int x) { val = x; }
}

void InOrderTraversal(TreeNode node, IList<int> list)
{
	if (node != null)
	{
		InOrderTraversal(node.left, list);
		//Console.Write(node.val + "\t");
		list.Add(node.val);
		InOrderTraversal(node.right, list);
	}
}

public class Solution
{
	int count = 0;
	int KthElement = Int32.MinValue;
	public int KthSmallest(TreeNode root, int k)
	{
		DoInOrderTraversal(root, k);
		return KthElement;
	}
	
	private void DoInOrderTraversal(TreeNode node, int k)
	{
		if (node != null)
		{
			DoInOrderTraversal(node.left, k);
			count++;
			if (count == k)
			{
				KthElement = node.val;
				return;
			}
			DoInOrderTraversal(node.right, k);
		}
	}
	public bool IsBalanced(TreeNode root)
	{
		if(root == null)
			return true;
		int leftHt = GetHeight(root.left);
		int rightHt = GetHeight(root.right);
		return (Math.Abs(leftHt - rightHt) <= 1) && IsBalanced(root.left) && IsBalanced(root.right);
	}
	
	public int GetHeight(TreeNode node)
	{
		if(node == null)
			return 0;
		return 1 + Math.Max(GetHeight(node.left), GetHeight(node.right));
	}
}