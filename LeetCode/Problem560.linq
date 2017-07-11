<Query Kind="Program" />

void Main()
{
	var input = new int[] { 0,0,0,0,0,0,0,0,0,0};	
	var ob = new Solution();
	ob.SubarraySum(input, 0).Dump();
}

// Define other methods and classes here
public class Solution
{
	public int SubarraySum(int[] nums, int k)
	{
		int count = 0;
		var sumDict = new Dictionary<int,int>();
		sumDict.Add(0,1);
        var sumSoFar = 0;              
        foreach(var num in nums)
        {
			sumSoFar += num;		
			
			if (sumDict.ContainsKey(sumSoFar - k))
				count += sumDict[sumSoFar - k];
				
			if(sumDict.ContainsKey(sumSoFar) == false)
				sumDict.Add(sumSoFar, 0);
			sumDict[sumSoFar] += 1;		
		}
		return count;
	}
}