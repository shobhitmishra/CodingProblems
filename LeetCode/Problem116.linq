<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.IO.dll</Reference>
</Query>

void Main()
{
	var root = new TreeLinkNode(5);

	var leftTree = new TreeLinkNode(4);
	leftTree.left = new TreeLinkNode(11);
	leftTree.left.left = new TreeLinkNode(7);
	leftTree.left.right = new TreeLinkNode(2);

	var rightTree = new TreeLinkNode(8);
	rightTree.left = new TreeLinkNode(13);
	rightTree.right = new TreeLinkNode(4);
	rightTree.right.left = new TreeLinkNode(5);
	rightTree.right.right = new TreeLinkNode(1);

	root.left = leftTree;
	root.right = rightTree;

	var ob = new Solution();
	ob.connect(root);
}

// Define other methods and classes here
public class TreeLinkNode
{
	public int val;
	public TreeLinkNode left, right, next;
	public TreeLinkNode(int x) { val = x; }
}

public class Solution
{
	public void connect(TreeLinkNode root)
	{
		// This is a normal level order traversal 
		var q = new Queue<TreeLinkNode>();
		q.Enqueue(root);
		while (q.Count() > 0)
		{
			int size = q.Count();
			var levelList = new List<TreeLinkNode>();
			for (int i = 0; i < size; i++)
			{
				var node = q.Dequeue();
				levelList.Add(node);
				if (node.left != null)
					q.Enqueue(node.left);
				if (node.right != null)
					q.Enqueue(node.right);
			}
			ConnectNodes(levelList);
		}
	}

	private void ConnectNodes(List<TreeLinkNode> list)
	{
		for (int i = 0; i < list.Count() - 1; i++)
		{
			list[i].next = list[i + 1];
		}
	}
}