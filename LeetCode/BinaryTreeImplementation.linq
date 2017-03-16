<Query Kind="Program" />

void Main()
{
	var bt = new BinaryTree(20);
	bt.AddANode(bt.Root, 10);
	bt.AddANode(bt.Root, 30);
	bt.AddANode(bt.Root, 5);
	bt.AddANode(bt.Root, 15);
	bt.AddANode(bt.Root, 25);
	bt.AddANode(bt.Root, 35);
	bt.AddANode(bt.Root, 12);
	bt.AddANode(bt.Root, 11);
	bt.AddANode(bt.Root, 32);
	bt.AddANode(bt.Root, 34);
	bt.AddANode(bt.Root, 45);
	bt.AddANode(bt.Root, 50);
	bt.InOrderTraversal(bt.Root);
	//bt.SearchANode(bt.Root, 35).Dump();
	Console.WriteLine("Deleting a node");	
	bt.DeleteANode(bt.Root, 20);
	Console.WriteLine ();
	bt.InOrderTraversal(bt.Root);
}

// Define other methods and classes here
public class BinaryTreeNode
{
	public BinaryTreeNode leftchild;
	public BinaryTreeNode rightChild;
	public int value;
	public BinaryTreeNode(int val)
	{
		value = val;
	}
}

interface BinarySearchTree
{
	void AddANode(BinaryTreeNode root, int value);
	BinaryTreeNode AddANode(BinaryTreeNode root, BinaryTreeNode node);
	BinaryTreeNode SearchANode(BinaryTreeNode root, int value);
	bool DeleteANode(BinaryTreeNode root, int value);
	//void DeleteANode(BinaryTreeNode root, BinaryTreeNode node);
}

public class BinaryTree
{
	public BinaryTreeNode Root {get; private set;}
	
	public BinaryTree(int value)
	{
		Root= new BinaryTreeNode(value);
	}
	
	public void AddANode(BinaryTreeNode root, int value)
	{
		var node = new BinaryTreeNode(value);
		AddANode(root, node);
	}
	
	public BinaryTreeNode AddANode(BinaryTreeNode root, BinaryTreeNode node)
	{
		if(root == null)
			return node;
		if(node.value < root.value)
		{
			root.leftchild = AddANode(root.leftchild, node);
		}
		else
		{
			root.rightChild = AddANode(root.rightChild, node);
		}
		return root;
	}
	
	public BinaryTreeNode SearchANode(BinaryTreeNode root, int value)
	{
		if(root != null)
		{
			if(root.value == value)
				return root;
			else if(value < root.value)
				return SearchANode(root.leftchild, value);
			else
				return SearchANode(root.rightChild, value);
		}
		return null;
	}
	
	public BinaryTreeNode DeleteANode(BinaryTreeNode root, int value)
	{
		if(root == null)
			return root;
		if(value < root.value)
			root.leftchild = DeleteANode(root.leftchild, value);
		else if(value > root.value)
			root.rightChild = DeleteANode(root.rightChild, value);
		else
		{
			// leaf
			if(root.leftchild == null && root.rightChild == null)
			{
				root = null;
				return root;
			}
			else if(root.leftchild == null && root.rightChild != null)
			{
				root = root.rightChild;				
			}
			else if(root.leftchild != null && root.rightChild == null)
			{
				root = root.leftchild;
			}
			else
			{
				var successor = FindSuccessor(root);
				root.value = successor.value;
				root.rightChild = DeleteANode(root.rightChild, successor.value);
			}
		}
		return root;
	}
	
	public void InOrderTraversal(BinaryTreeNode root)
	{
		if(root != null)
		{
			InOrderTraversal(root.leftchild);
			Console.Write(root.value +"\t");
			InOrderTraversal(root.rightChild);		
		}
	}
	
	private BinaryTreeNode FindSuccessor(BinaryTreeNode root)
	{		
		var successor = root;
		// go right once and keep going left
		successor = successor.rightChild;
		while(successor.leftchild != null)
			successor = successor.leftchild;
		return successor;
	}
	
	private int NumberOfChildren(BinaryTreeNode node)
	{
		if(node.leftchild == null && node.rightChild == null)
			return 0;
		else if(node.leftchild != null && node.rightChild != null)
			return 2;
		return 1;
	}
}