<Query Kind="Program" />

public static StreamReader fileInput;
public static StreamReader fileOutput;
public static int JumpSize = 1500;
public class Node
{
	public int value;
	public int depth;
	public Node parent;
	public List<Node> children;
	public List<Node> indexedParents;
	public Node(int val)
	{
		value = val;
		children = new List<Node>();
		indexedParents = new List<Node>();
	}
}

public class Tree
{
	public Node root;
	public Dictionary<int, Node> allNodes;
	public Tree()
	{
		allNodes = new Dictionary<int, Node>();		
	}
	public void AddNode(int nodeVal, int parentVal)
	{
		Node childNode;
		Node parentNode;
		if(!allNodes.TryGetValue(nodeVal, out childNode))
		{
			childNode = new Node(nodeVal);
			allNodes.Add(nodeVal, childNode);
		}
		if(parentVal == 0)
		{
			root = childNode;
			return;
		}
		if(!allNodes.TryGetValue(parentVal, out parentNode))
		{
			parentNode = new Node(parentVal);
			allNodes.Add(parentVal, parentNode);
		}
		childNode.parent = parentNode;
		childNode.depth = parentNode.depth + 1;				
		childNode.indexedParents.AddRange(parentNode.indexedParents);		
		parentNode.children.Add(childNode);
	}
	public void DeleteANode(int nodeVal)
	{
		Node desiredNode = allNodes[nodeVal];
		Node parentNode = desiredNode.parent;		
		allNodes.Remove(nodeVal);
		desiredNode = null;
	}
	public int FindKthAncestor(int nodeVal, int ancestor)
	{		
		if(!allNodes.ContainsKey(nodeVal))
			return 0;		
		Node desiredNode = allNodes[nodeVal];				
		int distanceFromRoot = desiredNode.depth - ancestor;
		if(distanceFromRoot < 0)
			return 0;
		if(distanceFromRoot % JumpSize == 0)
			return desiredNode.indexedParents[distanceFromRoot / JumpSize].value;
		
		int desiredParentIndex = (distanceFromRoot / JumpSize) + 1;
		Node currentNode = null;
		int distanceFromdesiredParent = 0;
		if(desiredParentIndex < desiredNode.indexedParents.Count)
		{
			currentNode = desiredNode.indexedParents[desiredParentIndex];
			distanceFromdesiredParent = desiredParentIndex * JumpSize - distanceFromRoot;
		}
		else
		{
			currentNode = desiredNode;
			distanceFromdesiredParent = ancestor;
		}
		while(distanceFromdesiredParent > 0)
		{
			if(currentNode == null)
				return 0;
			currentNode = currentNode.parent;
			distanceFromdesiredParent--;
		}
		if(currentNode == null)
			return 0;
		return currentNode.value;
	}
	
	public void BuildIndex()
	{
		// start BFS from the root node		
		root.indexedParents.Add(root);
		HashSet<Node> visitedNodes = new HashSet<Node>();
		Queue<Node> bfsQueue = new Queue<Node>();
		bfsQueue.Enqueue(root);
		visitedNodes.Add(root);
		while(bfsQueue.Count > 0)
		{
			Node current = bfsQueue.Dequeue();			
			foreach (var child in current.children.ToArray())
			{
				if(!visitedNodes.Contains(child))
				{					
					child.depth = current.depth + 1;					
					child.indexedParents.AddRange(current.indexedParents);
					if(child.depth % JumpSize == 0)
						child.indexedParents.Add(child);
					bfsQueue.Enqueue(child);
				}
			}
		}
	}
}

public static void Main()
{
	fileInput = new StreamReader(@"D:\HackerRank\TestCases\KthAncestor_input2.txt");
	fileOutput = new StreamReader(@"D:\HackerRank\TestCases\KthAncestor_output2.txt");
	
	int numOfTests = ParseInputLine().FirstOrDefault();
	
	for (int i = 0; i < numOfTests; i++)
	{
		StartTheProgram();
	}
	fileInput.Close();
	fileOutput.Close();
}

public static void StartTheProgram()
{
	Tree tree = new Tree();
	int numOfNodes = ParseInputLine().FirstOrDefault();
	for (int i = 0; i < numOfNodes; i++)
	{
		var input = ParseInputLine();
		tree.AddNode(input[0], input[1]);
	}
	tree.BuildIndex();
		
	HandleTheQueries(tree);
}

public static void HandleTheQueries(Tree tree)
{	
	int numOfQueries = ParseInputLine().FirstOrDefault();
	for (int i = 0; i < numOfQueries; i++)
	{
		var input = ParseInputLine();
		if(input[0] == 0)
		{
			tree.AddNode(input[2], input[1]);
		}
		else if(input[0] == 1)
		{
			tree.DeleteANode(input[1]);
		}
		else if(input[0] == 2)
		{			
			var output = tree.FindKthAncestor(input[1], input[2]);
			Console.WriteLine(output);
			
			var expected = fileOutput.ReadLine();
			if(output.ToString() != expected)
			{
				Console.WriteLine("ERROR {0}, {1}", output, expected);
			}
		}
	}
}

public static int[] ParseInputLine(bool flag = true)
{
	if(flag)
	{		
		return fileInput.ReadLine().Trim().Split().Select(x => Convert.ToInt32(x)).ToArray();
	}
	return Console.ReadLine().Trim().Split().Select(x => Convert.ToInt32(x)).ToArray();
}