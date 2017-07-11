<Query Kind="Program" />

void Main()
{
	var input = new char[] {'A','A','A','B','B','B'};
	var ob = new Solution();
	ob.LeastInterval(input, 2).Dump();
}

// Define other methods and classes here
public class Solution
{
	class MaxHeap
	{
		int capacity;
		int[] heap;
		int count = 0;
		
		public MaxHeap(int c)
		{
			capacity = c;
			heap = new int[c];
		}

		public void Insert(int val)
		{
			if(count == capacity)
				throw new ArgumentOutOfRangeException("Heap is full");
			heap[count++] = val;

			// bubble up
			int current = count - 1;
			while (current > 0)
			{
				int parentIndex = (current - 1) / 2;
				if(heap[parentIndex] >= heap[current])
					break;
				else
				{
					Swap(heap, current, parentIndex);					
					current = parentIndex;
				}
			}
		}

		public int GetMax()
		{
			if (count == 0)
				return -1;
			
			var max = heap[0];
			heap[0] = heap[count - 1];
			count--;

			// bubble down;
			int current = 0;
			while (current < count - 1)
			{
				var child1 = 2 * current + 1 < count ? heap[2 * current + 1] : int.MinValue;
				var child2 = 2 * current + 2 < count ? heap[2 * current + 2] : int.MinValue;
				if (heap[current] < Math.Max(child1, child2))
				{
					if (child1 > child2)
					{
						Swap(heap, current, 2 * current + 1);
						current =  2 * current + 1;
					}
					else
					{
						Swap(heap, current, 2 * current + 2);
						current = 2 * current + 2;
					}
				}
				else
					break;
				
			}			
			return max;
		}

		public bool IsEmpty()
		{
			return count == 0;
		}
		
		private void Swap(int[] arr, int index1, int index2)
		{
			var temp = arr[index1];
			arr[index1] = arr[index2];
			arr[index2] = temp;
		}
	}
	
	public int LeastInterval(char[] tasks, int n)
	{
		// Get the frequency of all the chars
		var frequency = new Dictionary<char,int>();
		foreach (var ch in tasks)
		{
			if(frequency.ContainsKey(ch) == false)
				frequency.Add(ch, 0);
			frequency[ch] +=1;
		}
		
		var heap = new MaxHeap(frequency.Keys.Count);
		var coolDown = new Dictionary<int,int>();
		foreach (var count in frequency.Values)
		{
			heap.Insert(count);
		}
		
		var timer = 0;
		while (heap.IsEmpty() == false || coolDown.Keys.Count > 0)
		{
			if (coolDown.ContainsKey(timer - n - 1))
			{
				var val = coolDown[timer -n -1];
				coolDown.Remove(timer -n -1);
				heap.Insert(val);
			}
			if (heap.IsEmpty() == false)
			{
				var max = heap.GetMax();
				if (max != -1)
				{
					if(max -1 != 0)
						coolDown.Add(timer, max -1);
				}
			}
			
			timer++;
		}
		
		return timer;
	}	
}