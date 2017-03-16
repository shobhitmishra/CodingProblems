<Query Kind="Program" />

void Main()
{
	var ob = new LRUCache(1);
	ob.Set(2,1);
	ob.Get(2);
	ob.Set(3,2);
	ob.Get(2);	
	ob.Get(3);	
	//ob.Print();
}
public class Node
{
	public Node prev;
	public Node next;
	public int key;
	public int value;
	public Node(int k, int v)
	{
		key = k;
		value = v;
	}
}
public class LRUCache
{
	// Least recently used on back and most recently used on front
	Node head, tail;
	int capacity;
	public Dictionary<int, Node> nodeDict = new Dictionary<int, Node>();
	public LRUCache(int capacity)
	{
		this.capacity = capacity;
	}

	private void SetHead(Node n)
	{
		if(n == null)
			return;
		n.next = head;
		if(head != null)
			head.prev = n;		
		head = n;
		if(tail == null)
			tail = head;
	}

//	public void Print()
//	{
//		//nodeDict.Dump("dictionary");
//		Console.WriteLine("start of Print");
//		var node = head;
//		while (node != null)
//		{
//			Console.WriteLine(node.value);
//			node = node.next;
//		}
//	}

	private void RemoveNode(Node n)
	{
		if(n == null)
			return;
		if(n.prev == null)
			head = n.next;
		else
			n.prev.next = n.next;			
		
		if(n.next == null)
			tail = n.prev;
		else
			n.next.prev = n.prev;
	}	
	public int Get(int key)
	{
		if (nodeDict.ContainsKey(key))
		{
			var node = nodeDict[key];
			RemoveNode(node);
			SetHead(node);
			return node.value;		
		}				
		return -1;		
	}

	public void Set(int key, int value)
	{
		if (nodeDict.ContainsKey(key))
		{
			var node = nodeDict[key];
			node.value = value;
			RemoveNode(node);
			SetHead(node);
		}
		else
		{
			var node = new Node(key, value);			
			if (nodeDict.Count() >= capacity)
			{
				RemoveNode(tail);
				nodeDict.Remove(tail.key);				
			}			
			SetHead(node);
			nodeDict.Add(key, node);
		}
		//Print();
	}
}