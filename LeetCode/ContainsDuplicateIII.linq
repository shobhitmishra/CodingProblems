<Query Kind="Program" />

void Main()
{
	var file = new StreamReader(@"D:\LeetCode\Test\ContainsDuplicates.txt");
	var line = file.ReadLine();
	//var nums = line.Split(new char[] {','}).Select(x => Convert.ToInt32(x)).ToArray();
	var nums = new int[] {3,6,0,4};
	var ob = new Solution();
	ob.ContainsNearbyAlmostDuplicate(nums,2,2).Dump();
	file.Close();
}

// Define other methods and classes here
public class Solution 
{	
	public class Elements
	{
		public int index;
		public int value;
		public Elements(int i, int v)
		{
			index = i;
			value = v;
		}
	}
    public bool ContainsNearbyAlmostDuplicate(int[] nums, int k, int t) 
    {
		if(nums == null || nums.Length <= 1)
            return false;
        var elements = nums.Select((v,i) => new Elements(i,v)).OrderBy(item => item.value).ToArray();
		int firstPtr = 0;		
		while(firstPtr < nums.Length)
		{
			int secondPtr = GetSecondPtr(firstPtr, elements, t);
			if(secondPtr <= firstPtr)
			{
				firstPtr++;
				continue;
			}
			if(IsNearerThanK(elements,firstPtr,secondPtr,k))
				return true;
			firstPtr = secondPtr;
		}
		return false;
    }
	
	private bool IsNearerThanK(Elements[] ele, int first, int second, int difference)
	{		
		var elements = ele.Skip(first).Take(second - first + 1).OrderBy(x => x.index).ToArray();
		int i = 0;
		while(i < elements.Length - 1)
		{
			if(Math.Abs(elements[i+1].index - elements[i].index) <= difference)
				return true;
			i++;
		}
		return false;
	}
	private int GetSecondPtr(int firstPtr, Elements[] elements, int t)
	{
		int secondptr = firstPtr;
		while(secondptr < elements.Length)
		{
			long diff = (long)elements[secondptr].value - (long)elements[firstPtr].value;
			if(diff > t)
				break;
			secondptr++;
		}
		return secondptr - 1;
	}
}