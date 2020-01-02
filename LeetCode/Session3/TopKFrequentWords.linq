<Query Kind="Program">
  <Namespace>static System.Linq.Enumerable</Namespace>
  <Namespace>System.IO</Namespace>
</Query>

void Main()
{
	var input = new string[] {"the", "day", "day", "day", "is", "sunny", "the", "the", "the", "sunny", "is", "is", "sunny"};
	var ob = new Solution();
	ob.TopKFrequent(input, 4).Dump();
}

public class Solution
{
	public IList<string> TopKFrequent(string[] words, int k)
	{
		var wordGroups = words.GroupBy(x => x).Select(y => new WordFrequencyCounter(y.Count(), y.Key));
		var minHeap = new MinHeap<WordFrequencyCounter>();
		foreach (var group in wordGroups)
		{
			minHeap.Enqueue(group);
			if (minHeap.Count() > k)
				minHeap.Dequeue();
		}
		return minHeap.GetAllItems().OrderByDescending(x => x.Frequency).ThenBy(y => y.Word).Select(z => z.Word).ToList();
	}
}

// Define other methods and classes here
public class WordFrequencyCounter : IComparable<WordFrequencyCounter>
{
	public int Frequency { get; }
	public string Word { get; }
	public WordFrequencyCounter(int freq, string word)
	{
		Frequency = freq;
		Word = word;
	}

	public int CompareTo(WordFrequencyCounter other)
	{
		if(this.Frequency == other.Frequency)
		{
			return other.Word.CompareTo(this.Word);
		}
		return this.Frequency - other.Frequency;
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