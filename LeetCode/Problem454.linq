<Query Kind="Program" />

void Main()
{
	var ob = new Solution();
	var A = new int[] {1, 2};
	var B = new int[] {-2, -1};
	var C = new int[] {-1,2};
	var D = new int[] {0,2};
	ob.FourSumCount(A,B,C,D).Dump();
}

// Define other methods and classes here
public class Solution
{
	public int FourSumCount(int[] A, int[] B, int[] C, int[] D)
	{
		int count = 0;		
		var cd_dict = new Dictionary<int,int>();
		for (int i = 0; i < C.Length; i++)
		{
			for (int j = 0; j < D.Length; j++)
			{
				var sum = C[i] + D[j];
				if(cd_dict.ContainsKey(sum) == false)
					cd_dict.Add(sum,0);
				cd_dict[sum] +=1;
			}
		}

		for (int i = 0; i < A.Length; i++)
		{
			for (int j = 0; j < B.Length; j++)
			{
				var sum = -1 * (A[i] + B[j]);
				if(cd_dict.ContainsKey(sum))
					count += cd_dict[sum];
			}
		}
		return count;
	}
}