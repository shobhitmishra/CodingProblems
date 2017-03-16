<Query Kind="Program" />

void Main()
{
	var input = new int[] { 1,2, 1, 1, 1, 2, 1, 2, 2, 2, 4, 5};
	var ob = new Solution();
	ob.MajorityElement(input).Dump();
}

// Define other methods and classes here
public class Solution
{
	public IList<int> MajorityElement(int[] nums)
	{
		int majority1 = Int32.MaxValue;
		int count1 = 0;
		int majority2 = Int32.MaxValue;
		int count2 = 0;
		foreach (var element in nums)
		{			
			if(majority1 == element)
				count1++;
			else if(majority2 == element)
				count2++;
			else if (count1 == 0)
			{
				majority1 = element;
				count1 = 1;
			}
			else if (count2 == 0)
			{
				majority2 = element;
				count2 = 1;
			}
			else
			{
				count1--;
				count2--;
			}
		}
		count1 = 0;
		count2 = 0;
		foreach (var element in nums)
		{
			if(element == majority1)
				count1++;
			else if(element == majority2)
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