<Query Kind="Program" />

void Main()
{
	var ob = new Solution();
	var input = new int[] {};
	ob.FindRelativeRanks(input).Dump();
}

// Define other methods and classes here
public class Solution
{
	public class IndexAndScore
	{
		public int index;
		public int score;
		public IndexAndScore(int i, int s)
		{
			this.index = i;
			this.score = s;
		}
	}
	public string[] FindRelativeRanks(int[] nums)
	{
		var scores = new IndexAndScore[nums.Length];
		var output = new string[nums.Length];
		for (int i = 0; i < nums.Length; i++)
		{
			scores[i] = new IndexAndScore(i, nums[i]);
		}
		scores = scores.OrderByDescending(x => x.score).ToArray();
		for (int i = 0; i < scores.Length; i++)
		{
			var index = scores[i].index;
			var rank = GetRank(i);
			output[index] = rank;
		}
		return output;
	}
	public string GetRank(int rank)
	{
		switch (rank)
		{
			case 0: return "Gold Medal";
			case 1: return "Silver Medal";
			case 2: return "Bronze Medal";
			default: return (rank + 1).ToString();
		}
	}
}