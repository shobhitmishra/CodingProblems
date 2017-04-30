<Query Kind="Program" />

void Main()
{
	LRUCache cache = new LRUCache(2 /* capacity */ );

	cache.Put(1, 1);
	cache.Put(2, 2);
	cache.Get(1).Dump();       // returns 1
	cache.Put(3, 3);    // evicts key 2
	cache.Get(2).Dump();       // returns -1 (not found)
	cache.Put(4, 4);    // evicts key 1
	cache.Get(1).Dump();       // returns -1 (not found)
	cache.Get(3).Dump();       // returns 3
	cache.Get(4.Dump());       // returns 4

}

// Define other methods and classes here
public class LRUCache
{
	class LLNode
	{
		public int key;
		public int value;
		public LLNode prev;
		public LLNode next;
		public LLNode(int k, int v)
		{
			key = k;
			value = v;
		}
	}
	int capacity;
	LLNode head, tail;
	int count = 0;
	Dictionary<int, LLNode> dict;

	public LRUCache(int capacity)
	{
		this.capacity = capacity;
		dict = new Dictionary<int, LLNode>();
	}

	public int Get(int key)
	{
		LLNode node;
		dict.TryGetValue(key, out node);
		if(node == null)
			return -1;
		Remove(node);
		AddToFront(node);
		return node.value;
	}

	public void Put(int key, int value)
	{
		// If node already exists then update its key
		if (dict.ContainsKey(key))
		{
			dict[key].value = value;
			Remove(dict[key]);
			AddToFront(dict[key]);
			return;
		}

		var node = new LLNode(key, value);
		if (count == capacity)
		{
			count--;
			dict.Remove(tail.key);
			Remove(tail);			
		}
		AddToFront(node);
		dict.Add(node.key, node);
		count++;
	}

	private void PrintLL()
	{
		var node = head;
		while (node != null)
		{
			Console.Write("{0}:{1}\t", node.key, node.value);
			node = node.next;
		}
		Console.WriteLine();
	}

	private void AddToFront(LLNode node)
	{
		if (head == null)
		{
			head = node;
			if(tail == null)
				tail = node;
			//Console.WriteLine("From Add");
			//PrintLL();
			return;
		}		
		node.next = head;
		head.prev = node;
		head = node;
		if(tail == null)
			tail = node;
		//Console.WriteLine("From Add");
		//PrintLL();
	}
	private void Remove(LLNode node)
	{
		if(node == null)
			return;
		if (node != head && node != tail)
		{
			node.prev.next = node.next;
			node.next.prev = node.prev;
			return;
		}
		if (node == head)
		{
			head = head.next;
			if (head != null)
				head.prev = null;
		}
		
		if (node == tail)
		{
			tail = tail.prev;
			if (tail != null)
				tail.next = null;
		}	
		
//		Console.WriteLine("From Remove");
//		PrintLL();
	}
}