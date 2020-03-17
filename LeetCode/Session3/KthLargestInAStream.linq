<Query Kind="Program" />

void Main()
{
	var input = new int[] { 4, 5, 8, 2};
	var kthLargest = new KthLargest(3, input);
	kthLargest.Add(3).Dump();   // returns 4
	kthLargest.Add(5).Dump();   // returns 5
	kthLargest.Add(10).Dump();  // returns 5
	kthLargest.Add(9).Dump();   // returns 8
	kthLargest.Add(4).Dump();   // returns 8
}

// Define other methods and classes here
public class KthLargest
{
	MinHeap<int> minHeap = new MinHeap<int>();
	int capacity;
	public KthLargest(int k, int[] nums)
	{
		capacity = k;
		foreach (var num in nums)
		{
			minHeap.Enqueue(num);
			if(minHeap.Count() > capacity)
				minHeap.Dequeue();
		}
	}

	public int Add(int val)
	{
		if(minHeap.Count() < capacity || minHeap.Peek() <= val)
			minHeap.Enqueue(val);
		if(minHeap.Count() > capacity)
			minHeap.Dequeue();
		return minHeap.Peek();
	}
}
public class MinHeap<T> where T : IComparable<T>
{
	private List<T> data;

	public MinHeap()
	{
		this.data = new List<T>();
	}

	public List<T> GetAllItems() => data;

	public void Enqueue(T item)
	{
		data.Add(item);
		int child = data.Count - 1; // child index; start at end
		while (child > 0)
		{
			int parent = (child - 1) / 2; // parent index
			if (data[child].CompareTo(data[parent]) >= 0) break; // child item is larger than (or equal) parent so we're done
			T tmp = data[child]; data[child] = data[parent]; data[parent] = tmp;
			child = parent;
		}
	}

	public T Dequeue()
	{
		if (data.Count == 0)
			throw new InvalidOperationException("Heap is empty.");

		int li = data.Count - 1; // last index (before removal)
		T frontItem = data[0];   // fetch the front
		data[0] = data[li];
		data.RemoveAt(li);

		--li; // last index (after removal)
		int parent = 0; // parent index. start at front of pq
		while (true)
		{
			int child = parent * 2 + 1; // left child index of parent
			if (child > li) break;  // no children so done
			int rightChild = child + 1;     // right child
			if (rightChild <= li && data[rightChild].CompareTo(data[child]) < 0) // if there is a rightChild (child + 1), and it is smaller than left child, use the rightChild instead
				child = rightChild;
			if (data[parent].CompareTo(data[child]) <= 0) break; // parent is smaller than (or equal to) smallest child so done
			T tmp = data[parent]; data[parent] = data[child]; data[child] = tmp; // swap parent and child
			parent = child;
		}
		return frontItem;
	}

	public T Peek()
	{
		T frontItem = data[0];
		return frontItem;
	}

	public int Count()
	{
		return data.Count;
	}
} // MinHeap