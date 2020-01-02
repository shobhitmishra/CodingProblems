<Query Kind="Program">
  <Namespace>static System.Linq.Enumerable</Namespace>
  <Namespace>System.IO</Namespace>
</Query>

void Main()
{
	var list1 = new int[]{3,3};
	var list2 = new int[]{5,-1};
	var list3 = new int[]{-2,4};
	var input = new int[][]{list1, list2, list3};
	var ob = new Solution();
	ob.KClosest(input,2).Dump();
}

public class Solution
{
	public int[][] KClosest(int[][] points, int K)
	{
		var maxHeap = new MaxHeap<Points>();
		foreach (var point in points)
		{
			var p = new Points(point[0], point[1]);
			maxHeap.Enqueue(p);
			if(maxHeap.Count() > K)
				maxHeap.Dequeue();
		}
		return maxHeap.GetAllItems().Select(x => new int[] {x.X, x.Y}).ToArray();
	}
}

public class Points : IComparable<Points>
{
	public int X { get; }
	public int Y { get; }
	public Points(int x, int y)
	{
		this.X = x;
		this.Y = y;
	}
	public int DistanceFromOrigin => X*X + Y*Y;
	
	public int CompareTo(Points other)
	{
		var aDist = this.DistanceFromOrigin;
		var bDist = other.DistanceFromOrigin;
		return aDist - bDist;
	}
}

// Define other methods and classes here
public class MaxHeap<T> where T : IComparable<T>
{
	private List<T> data;

	public MaxHeap()
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
			if (data[child].CompareTo(data[parent]) <= 0) break; // child item is smaller than (or equal) parent so we're done
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
			if (rightChild <= li && data[rightChild].CompareTo(data[child]) > 0) // if there is a rightChild (child + 1), and it is great than left child, use the rightChild instead
				child = rightChild;
			if (data[parent].CompareTo(data[child]) >= 0) break; // parent is greatet than (or equal to) bigger child so done
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
} // MaxHeap