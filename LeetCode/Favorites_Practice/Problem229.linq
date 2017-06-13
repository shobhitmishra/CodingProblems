<Query Kind="Program" />

void Main()
{
	var ob = new Solution();
	var input = new int[] {1,1,1,1,2,2,2,3,4};
	ob.MajorityElement(input).Dump();
}

// Define other methods and classes here
public class Solution
{
	public IList<int> MajorityElement(int[] nums)
	{
		int majority1, majority2, count1, count2;
		majority1 = majority2 = Int32.MaxValue;
		count1 = count2 = 0;
		foreach (var num in nums)
		{
			if(num == majority1)
				count1++;
			else if(num == majority2)
				count2++;
			else if (count1 == 0)
			{
				majority1 = num;
				count1 = 1;
			}
			else if (count2 == 0)
			{
				majority2 = num;
				count2 = 1;
			}
			else
			{
				count1--;
				count2--;
			}
		}
		count1 = count2 = 0;
		foreach (var num in nums)
		{
			if(num == majority1)
				count1++;
			else if(num == majority2)
				count2++;
		}
		var result = new List<int>();
		if(count1 > nums.Length / 3)
			result.Add(majority1);
		if(count2 > nums.Length / 3)
			result.Add(majority2);
		return result;
	}
}