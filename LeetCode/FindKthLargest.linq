<Query Kind="Program" />

void Main()
{
	var input = new int[] {3,6,4,1,2,5,7,9,8,3,4,2};
	var ob = new Solution();
	ob.FindKthLargest(input, 9).Dump();
}

// Define other methods and classes here
public class MinHeap
{
	int currentSize;
	int[] heap;
	public MinHeap(int size)
	{		
		heap = new int[size];
		currentSize = 0;
	}	

	public int Insert(int num)
	{
		if (currentSize == heap.Length)
		{
			heap[0] = num;
			HeapifyDown();
			return num;
		}
		heap[currentSize] = num;		
		currentSize++;		
		HeapifyUp();		
		return num;
	}
	
	public int GetMin()
	{
		if(currentSize == 0)
			return -Int32.MaxValue;
		return heap[0];
	}
	
	public int GetCurrentSize()
	{
		return currentSize;			
	}
	private void HeapifyDown()
	{
		int currentIndex = 0;
		while (currentIndex < currentSize)
		{
			int child1 = 2 * currentIndex + 1;
			int child2 = 2 * currentIndex + 2;
			if(child1 >= currentSize)
				break;
			int smallerChildIndex = child1;
			if(child2 < currentSize && heap[child2] < heap[child1])
				smallerChildIndex = child2;
			
			if(heap[currentIndex] <= heap[smallerChildIndex])
				break;
			else
			{
				Swap(heap, currentIndex, smallerChildIndex);
				currentIndex = smallerChildIndex;
			}
		}
	}
	private void HeapifyUp()
	{
		int currentIndex = currentSize -1;
		int parentIndex = (currentIndex - 1) / 2;
		while (heap[parentIndex] > heap[currentIndex])
		{
			Swap(heap, parentIndex, currentIndex);
			currentIndex = parentIndex;
			parentIndex = (currentIndex - 1) / 2;
		}
	}
	private void Swap(int[] arr, int idx1, int idx2)
	{
		int temp = arr[idx1];
		arr[idx1] = arr[idx2];
		arr[idx2] = temp;
	}
	
}
public class Solution
{	
	public int FindKthLargest(int[] nums, int k)
	{
		var minHeap = new MinHeap(k);
		foreach (var element in nums)
		{
			if(minHeap.GetCurrentSize() < k || minHeap.GetMin() < element)
				minHeap.Insert(element);			
		}
		return minHeap.GetMin();
	}
}