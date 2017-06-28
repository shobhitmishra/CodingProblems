<Query Kind="Program" />

void Main()
{
	var root = new TreeNode(10);

	var leftSubtree = new TreeNode(20);
	leftSubtree.left = new TreeNode(1);
	leftSubtree.right = new TreeNode(8);
	leftSubtree.right.left = new TreeNode(6);
	leftSubtree.right.right = new TreeNode(9);

	var rightSubTree = new TreeNode(5);
	rightSubTree.left = new TreeNode(15);
	rightSubTree.right = new TreeNode(40);
	rightSubTree.right.left = new TreeNode(30);
	rightSubTree.right.right = new TreeNode(70);

	root.left = leftSubtree;
	root.right = rightSubTree;


	var ob = new Codec();
	var serialize = ob.serialize(root);
	var node = ob.deserialize(serialize);
}

// Define other methods and classes here
public class TreeNode
{
	public int val;
	public TreeNode left;
	public TreeNode right;
	public TreeNode(int x) { val = x; }
}

public class Codec
{
	string nulllStr = "#";
	char seperator = ',';
	
	// Encodes a tree to a single string.
	public string serialize(TreeNode root)
	{
		var result = new List<string>();
		SerializeHelper(root, result);
		return string.Join(seperator.ToString(), result);
	}

	// Decodes your encoded data to tree.
	public TreeNode deserialize(string data)
	{
		var dataList = data.Split(new char[] { seperator});
		var q = new Queue<string>(dataList);
		return DeserializeHelper(q);
	}
	
	private void SerializeHelper(TreeNode root, List<string> result)
	{
		if (root == null)
		{
			result.Add(nulllStr);
			return;
		}
		result.Add(root.val.ToString());
		SerializeHelper(root.left, result);
		SerializeHelper(root.right, result);
	}
	
	private TreeNode DeserializeHelper(Queue<string> q)
	{
		if(q.Count() == 0)
			return null;
		var val = q.Dequeue();
		if(val == nulllStr)
			return null;
		
		var node = new TreeNode(int.Parse(val));
		node.left = DeserializeHelper(q);
		node.right = DeserializeHelper(q);
		return node;
	}
}