<Query Kind="Program" />

void Main()
{
	var ob = new Solution();
	var input = new int[] {6,6,5,5,5,4,4,4,4,4,1,1,1,1,1,1,1,1,1,1,2,2,2,2,2,2,2,2};
	ob.TopKFrequent(input,3).Dump();
}

// Define other methods and classes here
public class Solution
{
	public class ValFrequncy
	{
		public int value;
		public int frequency;
		public ValFrequncy(int v, int f)
		{
			value = v;
			frequency = f;
		}
	}

	public class MinHeap
	{
		int capacity;
		int currentCount = 0;
		public ValFrequncy[] elements;
		public MinHeap(int c)
		{
			capacity = c;
			elements = new ValFrequncy[c];
		}
		
		public void AddElement(ValFrequncy val)
		{
			if (currentCount >= capacity)
			{
				// Add and bubbleDown
				if (val.frequency > elements[0].frequency)
				{
					elements[0] = val;
					BubbleDown();
				}
			}
			else
			{
				elements[currentCount] = val;
				int curr = currentCount;
				while (curr > 0 && elements[curr].frequency < elements[curr / 2].frequency)
				{
					// swap 
					var temp = elements[curr];
					elements[curr] = elements[curr/2];
					elements[curr/2] = temp;					
					curr = curr / 2;
				}
				currentCount++;
			}
		}
		private void BubbleDown()
		{
			var curr = 0;
			while (curr * 2 + 1 < capacity)
			{
				var firstChild = curr * 2 + 1;
				var secondChild = curr * 2 + 2;				
				var minChildIndex = firstChild;
				if (secondChild < capacity)
				{
					if (elements[secondChild].frequency < elements[firstChild].frequency)
					{						
						minChildIndex = secondChild;
					}
				}
				if(elements[curr].frequency < elements[minChildIndex].frequency)
					break;
				// else swap
				var temp = elements[curr];
				elements[curr] =  elements[minChildIndex];
				elements[minChildIndex] = temp;				
				curr = minChildIndex;
			}
		}
	}
	
	public IList<int> TopKFrequent(int[] nums, int k)
	{
		var dict = new Dictionary<int,int>();
		foreach (var num in nums)
		{
			if(dict.ContainsKey(num) == false)
				dict.Add(num,0);
			dict[num] +=1;
		}
		var allElements = new List<ValFrequncy>();
		foreach (var element in dict)
		{
			allElements.Add(new ValFrequncy(element.Key, element.Value));
		}
		
		// heap sorted by frequency
		var heap = new MinHeap(k);
		foreach (var element in allElements)
		{
			heap.AddElement(element);
		}
		return heap.elements.Select(x => x.value).ToArray();
	}	
}