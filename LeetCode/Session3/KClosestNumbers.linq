<Query Kind="Program">
  <Namespace>static System.Linq.Enumerable</Namespace>
</Query>

void Main()
{
	var nums = new int[] {1,2,3,4,5};
	var ob = new Solution();
	ob.FindClosestElements(nums,4, -1).Dump();
}

// Define other methods and classes here
public class Solution
{
	public IList<int> FindClosestElements(int[] arr, int k, int x)
	{
		// First Find the index of the nuber closest to x
		var closestIndex = FindClosestToTheTarget(arr, x);
		var i = closestIndex -1;
		var j = closestIndex + 1;
		var count = 1;		
		while(count < k){
            if(i < 0) j++;
            else if(j >= arr.Length) i--;
            else if(Math.Abs(arr[i] - x) <= Math.Abs(arr[j] - x)) i--;
            else j++;
            count++;
        }
		return arr.Skip(i+1).Take(k).ToList();
	}
	
	private int FindClosestToTheTarget(int[] arr, int target)
	{
		int start = 0, end = arr.Length - 1;
		while(start <= end)
		{
			var mid = start + (end - start) / 2;
			if (target == arr[mid])
				return mid;
			if (target > arr[mid])
				start = mid + 1;
			else
				end = mid - 1;
		}
		long startNum = start < arr.Length ? arr[start] : int.MaxValue;
		long endNum = end >= 0 ? arr[end]: int.MaxValue;
		if(Math.Abs(target - startNum) < Math.Abs(endNum - target))
			return start;
		return end;
	}
}