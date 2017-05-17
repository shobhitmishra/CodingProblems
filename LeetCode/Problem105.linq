<Query Kind="Program" />

void Main()
{
	var root = new TreeNode(10);
	root.left = new TreeNode(8);
	root.left.right = new TreeNode(9);

	var node_3 = new TreeNode(3);
	root.left.left = node_3;
	node_3.left = new TreeNode(2);
	node_3.left.left = new TreeNode(1);
	node_3.right = new TreeNode(6);
	node_3.right.right = new TreeNode(7);

	root.right = new TreeNode(40);
	root.right.left = new TreeNode(20);
	var node_70 = new TreeNode(70);
	root.right.right = node_70;

	node_70.left = new TreeNode(50);
	var node_80 = new TreeNode(80);
	node_70.right = node_80;
	node_80.left = new TreeNode(75);
	node_80.right = new TreeNode(90);
	node_80.right.left = new TreeNode(85);

	var inOrder = new List<int>();
	var postOrder = new List<int>();

	InOrderTraversal(root, inOrder);
	PreOrderTraversal(root, postOrder);

	var ob = new Solution();
	var rootResult = ob.BuildTree(inOrder.ToArray(), postOrder.ToArray());
	//var rootResult = ob.BuildTree(new int[] { 3, 2, 1 }, new int[] { 3, 2, 1 });

	var deserializedInOrder = new List<int>();
	var deserializedPostOrder = new List<int>();
	InOrderTraversal(rootResult, deserializedInOrder);
	PreOrderTraversal(rootResult, deserializedPostOrder);
	deserializedInOrder.Dump();
	deserializedPostOrder.Dump();
}

public void InOrderTraversal(TreeNode root, List<int> result)
{
	if (root != null)
	{
		InOrderTraversal(root.left, result);
		result.Add(root.val);
		InOrderTraversal(root.right, result);
	}
}

public void PreOrderTraversal(TreeNode root, List<int> result)
{
	if (root != null)
	{
		result.Add(root.val);
		PreOrderTraversal(root.left, result);
		PreOrderTraversal(root.right, result);		
	}
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
	public TreeNode BuildTree(int[] preorder, int[] inorder)
	{
		var preOrderQ = new Queue<int>(preorder);
		return BuildTreeHelper(preOrderQ, 0, inorder.Length - 1, inorder);
	}
	
	private TreeNode BuildTreeHelper(Queue<int> preOrder, int start, int end, int[] inorder)
	{
		if(start > end)
			return null;
		
		var rootVal = preOrder.Dequeue();
		var root = new TreeNode(rootVal);
		
		var rootIndex = FindRootIndex(rootVal, start, end, inorder);
		root.left = BuildTreeHelper(preOrder, start, rootIndex -1, inorder);
		root.right = BuildTreeHelper(preOrder, rootIndex + 1, end, inorder);
		return root;
	}

	private int FindRootIndex(int val, int start, int end, int[] inOrder)
	{
		for (int i = start; i <= end; i++)
		{
			if (inOrder[i] == val)
				return i;
		}
		return -1;
	}
}
