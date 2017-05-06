<Query Kind="Program" />

void Main()
{
	var ob = new Solution();
	var input1 = new int[] { 1, 2, 2, 1 };
	var input2 = new int[] { };
	ob.Intersect(input1, input2).Dump();
}

// Define other methods and classes here
public class Solution
{
	public int[] Intersect(int[] nums1, int[] nums2)
	{
		var num1Dict = nums1.GroupBy(x => x).ToDictionary(y => y.Key, y=> y.Count());
		var num2Dict = nums2.GroupBy(x => x).ToDictionary(y => y.Key, y=> y.Count());
		
		var result = new List<int>();
		foreach (var element in num1Dict)
		{
			var key = element.Key;
			if (num2Dict.ContainsKey(key))
			{
				var min = Math.Min(num1Dict[key], num2Dict[key]);
				result.AddRange(Enumerable.Repeat(key, min));
			}
		}
		return result.ToArray();
	}
}