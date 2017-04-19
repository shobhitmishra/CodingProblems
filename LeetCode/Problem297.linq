<Query Kind="Program" />

void Main()
{
	var root = new TreeNode(50);
	root.left = new TreeNode(20);
	root.left.left = new TreeNode(10);
	root.left.right = new TreeNode(30);
	root.left.right.left = new TreeNode(25);
	root.left.right.right = new TreeNode(40);
	root.left.right.right.left = new TreeNode(35);
	root.left.right.right.left.left = new TreeNode(32);
	root.left.right.right.right = new TreeNode(41);
	root.left.right.right.right.right = new TreeNode(42);
	root.right = new TreeNode(70);
	root.right.left = new TreeNode(60);
	root.right.right = new TreeNode(80);
	var ob = new Codec();
	var serialize = ob.serialize(new TreeNode(1));
	var newRoot = ob.deserialize(serialize);
	var newSerialize = ob.serialize(newRoot);
	Console.WriteLine(serialize);
	Console.WriteLine(newSerialize);
}

// Define other methods and classes here
public class TreeNode {
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int x) { val = x; }
}

public class Codec
{
	string nullRepresentation = "#";
	string delimiter = ",";
	
	// Encodes a tree to a single string.
	public string serialize(TreeNode root)
	{		
		var serializedList = new List<string>();
		SerializeHelper(root, serializedList);
		return string.Join(delimiter, serializedList);
	}

	private void SerializeHelper(TreeNode root, List<string> serializedList)
	{
		if (root == null)
		{
			serializedList.Add(nullRepresentation);
			return;
		}
		// append the node value
		serializedList.Add(root.val.ToString());
		SerializeHelper(root.left, serializedList);
		SerializeHelper(root.right, serializedList);
	}	

	// Decodes your encoded data to tree.
	public TreeNode deserialize(string data)
	{
		var dataQ = new Queue<string>(data.Split(delimiter[0]));
		return DeserializeHelper(dataQ);
	}
	
	private TreeNode DeserializeHelper(Queue<string> dataQ)
	{
		if(dataQ.Count == 0)
			return null;
		var val = dataQ.Dequeue();
		if(val == nullRepresentation)
			return null;
		var node = new TreeNode(Int32.Parse(val));
		node.left = DeserializeHelper(dataQ);
		node.right = DeserializeHelper(dataQ);
		return node;
	}
}