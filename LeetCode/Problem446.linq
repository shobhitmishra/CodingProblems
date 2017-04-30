<Query Kind="Program" />

void Main()
{
	var nums = new int[] { 0,2000000000,-294967296};
	var ob = new Solution();
	ob.NumberOfArithmeticSlices(nums).Dump();
}

// Define other methods and classes here
public class Solution
{
	public int NumberOfArithmeticSlices(int[] A)
	{
		if(A.Length <= 2)
			return 0;
		
		var leftFrequency = new Dictionary<long,long>[A.Length];
		leftFrequency[0] = new Dictionary<long,long>();
		for (int i = 1; i < A.Length; i++)
		{
			leftFrequency[i] = new Dictionary<long,long>();
			// copy all the keys from the left one
			foreach (var element in leftFrequency[i-1])
			{
				leftFrequency[i].Add(element.Key, element.Value);
			}
			var leftNum = A[i-1];
			if(leftFrequency[i].ContainsKey(leftNum) == false)
				leftFrequency[i].Add(leftNum, 0);
			leftFrequency[i][leftNum] +=1;
		}
		
		long count = 0;
		var subSequenceDict = new Dictionary<long,long>[A.Length];
		subSequenceDict[0] = subSequenceDict[1] = new Dictionary<long,long>();
		
		for (int i = 2; i < A.Length; i++)
		{
			subSequenceDict[i] = new Dictionary<long,long>();
			for (int j = i - 1; j >= 1; j--)
			{
				var diff = (long)A[i] - A[j];
				// check if the j already has a subsequence with this key
				// if it does then extend the subsequence by adding this num
				if (subSequenceDict[j].ContainsKey(diff))
				{
					if(subSequenceDict[i].ContainsKey(diff) == false)
						subSequenceDict[i].Add(diff,0);
					subSequenceDict[i][diff] += subSequenceDict[j][diff];
					count += subSequenceDict[j][diff];
				}

				// check if we can create new subsequences using this diff
				var previousSubSequenceNum = A[j] - diff;
				if (leftFrequency[j].ContainsKey(previousSubSequenceNum))
				{
					var countOfPrev = leftFrequency[j][previousSubSequenceNum];
					if (subSequenceDict[i].ContainsKey(diff) == false)
						subSequenceDict[i].Add(diff, 0);
					subSequenceDict[i][diff] += countOfPrev;
					count += countOfPrev;
				}
			}
		}
		return (int)count;
	}
}