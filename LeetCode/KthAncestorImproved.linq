<Query Kind="Program" />

public static StreamReader fileInput;
public static StreamReader fileOutput;

public class Node
{
	public int value;
	public int depth;
	public Node parent;
	public List<Node> children;
	public Node[] indexedParents;
	public Node(int val)
	{
		value = val;
		children = new List<Node>();
		indexedParents = new Node[4];
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
	public void AddNode(int nodeVal, int parentVal, bool queryAdd = false)
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
		if(queryAdd)
		{
			Array.Copy(parentNode.indexedParents, childNode.indexedParents, parentNode.indexedParents.Length);
			if(parentNode.depth % 10 == 0)
				SetIndex(childNode.indexedParents, parentNode);
		}
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
		return FindKthAncestorHelper(desiredNode, ancestor);
	}
	
	public int FindKthAncestorHelper(Node node, int kthancestor)
	{		
		if(kthancestor > node.depth)
			return 0;
		if(kthancestor == 0)
			return node.value;
		if(kthancestor <= 10)
			return FindKthAncestorHelper(node.parent, kthancestor -1);
		Node bestMatch = FindBestMatching(node.indexedParents, kthancestor);
		int jump = node.depth - bestMatch.depth;			
		return FindKthAncestorHelper(bestMatch, kthancestor - jump);
	}
	
	public Node FindBestMatching(Node[] indexedParents, int kthancestor)
	{
		if(kthancestor >= 10000)
			return indexedParents[3];
		if(kthancestor >= 1000 && kthancestor < 10000)
			return indexedParents[2];
		if(kthancestor >= 100 && kthancestor < 1000)
			return indexedParents[1];
		return indexedParents[0];
	}
	
	public void BuildIndex()
	{
		// start BFS from the root node				
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
					Array.Copy(current.indexedParents, child.indexedParents, current.indexedParents.Length);
					if(current.depth % 10 == 0)
						SetIndex(child.indexedParents, current);
					bfsQueue.Enqueue(child);
				}
			}
		}
	}
	
	public void SetIndex(Node[] indexedParents, Node current)
	{
		if(current.depth % 10 == 0)
			indexedParents[0] = current;
		if(current.depth % 100 == 0)
			indexedParents[1] = current;
		if(current.depth % 1000 == 0)
			indexedParents[2] = current;
		if(current.depth % 10000 == 0)
			indexedParents[3] = current;
	}
}

public static void Main()
{
	fileInput = new StreamReader(@"D:\HackerRank\TestCases\KthAncestor_input6.txt");
	fileOutput = new StreamReader(@"D:\HackerRank\TestCases\KthAncestor_output6.txt");
	
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
			tree.AddNode(input[2], input[1], true);
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