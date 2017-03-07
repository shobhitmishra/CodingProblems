<Query Kind="Program" />

void Main()
{
	var ob = new Solution();
	var result = ob.GetPermutation(5,24);
	result.Dump();
}

// Define other methods and classes here
public class Solution 
{
    public string GetPermutation(int n, int k) 
	{
		k -=1;
        Dictionary<int, long> fact = new Dictionary<int, long>();
		fact.Add(0,1);
		int prev = 1;
		for (int i = 1; i <= n; i++)
		{
			int current = prev * i;
			fact.Add(i,current);
			prev = current;
		}
		
		List<int> sortedList = Enumerable.Range(1,n).ToList();
		List<int> finalList = new List<int>();
		while (sortedList.Count() > 0)
		{
			long splitSize = fact[sortedList.Count() - 1];
			int index = (int)(k / splitSize);
			finalList.Add(sortedList[index]);
			sortedList.RemoveAt(index);
			k -= (int)(index * splitSize);
		}
		return string.Join("", finalList);
    }
}