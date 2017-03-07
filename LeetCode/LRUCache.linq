<Query Kind="Program" />

void Main()
{
	var ob = new LRUCache(10);
	ob.Set(10,13);
	ob.Set(3,17);
	ob.Set(6,11);
	ob.Set(10,5);
	ob.Set(9,10);
	ob.Get(13);
	ob.Set(2,19);
	ob.Get(2);
	ob.Get(3);
	ob.Set(5,25);
	ob.Get(8);
	ob.Set(9,22);
	ob.Set(5,5);
	ob.Set(1,30);
	ob.Get(11);
	ob.Set(9,12);
	ob.Get(7);
	ob.Get(5);
	ob.Get(8);
	ob.Get(9);
	ob.Set(4,30);
	ob.Set(9,3);
	ob.Get(9);
	ob.Get(10);
	ob.Get(10);
	ob.Set(6,14);
	ob.Set(3,1);
	ob.Get(3);
	ob.Set(10,11);
	ob.Get(8);
	ob.Set(2,14);
	ob.Get(1);
	ob.Get(5);
	ob.Get(4);
	ob.Set(11,4);
	ob.Set(12,24);
	ob.Set(5,18);
	ob.Get(13);
	ob.Set(7,23);
	ob.Get(8);
	ob.Get(12);
	ob.Set(3,27);
	ob.Set(2,12);
	ob.Get(5);
	ob.Set(2,9);
	ob.Set(13,4);
	ob.Set(8,18);
	ob.Set(1,7);
	ob.Get(6);
	ob.Set(9,29);
	ob.Set(8,21);
	ob.Get(5);
	ob.Set(6,30);
	ob.Set(1,12);
	ob.Get(10);
	ob.Set(4,15);
	ob.Set(7,22);
	ob.Set(11,26);
	ob.Set(8,17);
	ob.Set(9,29);
	ob.Get(5);
	ob.Set(3,4);
	ob.Set(11,30);
	ob.Get(12);
	ob.Set(4,29);
	ob.Get(3);
	ob.Get(9);
	ob.Get(6);
	ob.Set(3,4);
	ob.Get(1);
	ob.Get(10);
	ob.Set(3,29);
	ob.Set(10,28);
	ob.Set(1,20);
	ob.Set(11,13);
	ob.Get(3);
	ob.Set(3,12);
	ob.Set(3,8);
	ob.Set(10,9);
	ob.Set(3,26);
	ob.Get(8);
	ob.Get(7);
	ob.Get(5);
	ob.Set(13,17);
	ob.Set(2,27);
	ob.Set(11,15);
	ob.Get(12);
	ob.Set(9,19);
	ob.Set(2,15);
	ob.Set(3,16);
	ob.Get(1);
	ob.Set(12,17);
	ob.Set(9,1);
	ob.Set(6,19);
	ob.Get(4);
	ob.Get(5);
	ob.Get(5);
	ob.Set(8,1);
	ob.Set(11,7);
	ob.Set(5,2);
	ob.Set(9,28);
	ob.Get(1);
	ob.Set(2,2);
	ob.Set(7,4);
	ob.Set(4,22);
	ob.Set(7,24);
	ob.Set(9,26);
	ob.Set(13,28);
	ob.Set(11,26);
}

// Define other methods and classes here
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
	Node head = null;
	Node tail = null;
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
		n.prev = null;
		
		if(head != null)
			head.prev = n;		
		
		head = n;
		
		if(tail == null)
			tail = head;
	}

	public void Print()
	{
		//nodeDict.Dump("dictionary");
		Console.WriteLine("start of Print");
		var node = head;
		while (node != null)
		{
			Console.WriteLine(node.value);
			node = node.next;
		}
	}

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
			//Console.WriteLine("Get result {0}", node.value);
			return node.value;		
		}
		//Console.WriteLine("Get result {0}", -1);
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
				nodeDict.Remove(tail.key);	
				RemoveNode(tail);							
			}			
			SetHead(node);
			
			nodeDict.Add(key, node);
		}
		//Print();
	}
}