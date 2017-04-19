<Query Kind="Program" />

void Main()
{
	var ob = new Solution();
	var mArr = new int[] {2,5,6,4,4,0};
	var nArr = new int[] { 7, 3, 8, 0, 6, 5, 7, 6, 2 };
	//var mArr = new int[] { 6, 7 };
	//var nArr = new int[] { 6, 0, 4};
	int k = 15;
	ob.MaxNumber(mArr, nArr, k).Dump();
}
// Define other methods and classes here
public class Solution
{
	public int[] MaxNumber(int[] nums1, int[] nums2, int k)
	{
		var result = new int[k];	

		//get i nums from nums1 and k - i numbers from nums2
		for (int i = Math.Min(k, nums1.Length); i>=0 && k - i <= nums2.Length; i--)
		{
			var arr1Numbers = GetKFromOneArr(nums1, i);
			var arr2Numbers = GetKFromOneArr(nums2, k - i);
			var candidateSolution = Merge(arr1Numbers, arr2Numbers, k);
			
			if(IsCandidateBigger(candidateSolution,  result))
				result = candidateSolution;
		}
		return result;
	}	
	
	private int[] Merge(int[] arr1Numbers, int[] arr2Numbers, int k)
	{
		var result = new int[k];
		for (int i = 0, j = 0, r = 0; r < k; r++)
		{
			result[r] = Greater(arr1Numbers, i, arr2Numbers, j) ? arr1Numbers[i++] : arr2Numbers[j++];
		}
		return result;
	}
	
	private bool Greater(int[] arr1Numbers, int i, int[] arr2Numbers, int j)
	{
		while (i < arr1Numbers.Length && j < arr2Numbers.Length && arr1Numbers[i] == arr2Numbers[j])
		{
			i++;
			j++;
		}
		if(i == arr1Numbers.Length)
			return false;
		if(j == arr2Numbers.Length)
			return true;
		return arr1Numbers[i] > arr2Numbers[j];
	}
	
	private bool IsCandidateBigger(int[] candidate, int[] currentBest)
	{
		for (int i = 0; i < candidate.Length; i++)
		{
			if(candidate[i] > currentBest[i])
				return true;
			if(candidate[i] < currentBest[i])
				return false;
		}
		return true;	
	}
	
	public int[] GetKFromOneArr(int[] arr, int k)
	{		
		var stack = new Stack<int>();		
		for(int i = 0; i < arr.Length; i++)
		{
			var num = arr[i];
			var remaining = arr.Count() - i;
			if (stack.Count() > 0)
			{
				while (stack.Peek() < num && stack.Count() + remaining > k)
				{
					stack.Pop();
					if (stack.Count == 0)
						break;
				}
			}
			if(stack.Count() < k)
				stack.Push(num);
			
		}
		return stack.Reverse().ToArray();
	}
}