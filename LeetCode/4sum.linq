<Query Kind="Program" />

void Main()
{
	var nums = new int[]{0, 0, 0, 0, };
	var ob = new Solution();
	ob.FourSum(nums, 0).Dump();
}

// Define other methods and classes here
public class Solution 
{
	public class Pair
	{
		public int index1;
		public int index2;
		public Pair(int num1, int num2)
		{
			index1 = num1;
			index2 = num2;
		}
	}
	
    public IList<IList<int>> FourSum(int[] nums, int target) 
	{
		var alreadyCovered = new HashSet<string>();
		Array.Sort(nums);
        var dict = GetDictionary(nums);
//		dict.Dump();
		var result = new List<IList<int>>();
		foreach (var element in dict)
		{
			var list1 = element.Value;
			int remaining = target - element.Key;
			if(remaining == element.Key)
			{
				for (int i = 0; i < list1.Count; i++)
				{
					for (int j = i + 1; j < list1.Count; j++)
					{
						if(IsValidPair(list1[i], list1[j]))
						{
							var tempList = new List<int>()
							{nums[list1[i].index1], nums[list1[i].index2], nums[list1[j].index1], nums[list1[j].index2] };						
							if(!IsAlreadyCovered(tempList, alreadyCovered))
								result.Add(tempList);
							
						}
					}
				}
			}			
			if(dict.ContainsKey(remaining))
			{
				var list2 = dict[remaining];
				foreach (var pairA in list1)
				{
					foreach (var pairB in list2)
					{
						if(IsValidPair(pairA, pairB))
						{
							var tempList = new List<int>()
							{nums[pairA.index1], nums[pairA.index2], nums[pairB.index1], nums[pairB.index2]};
							if(!IsAlreadyCovered(tempList, alreadyCovered))
								result.Add(tempList);
						}
					}
				}
			}		
		}
		
		return result;
    }
	
	public bool IsAlreadyCovered(List<int> list, HashSet<string> alreadyCovered)
	{
		list.Sort();
		var str = string.Join("",list);
		 if(alreadyCovered.Contains(str))
			return true;
		else
			alreadyCovered.Add(str);
		return false;
	}
	public bool IsValidPair(Pair a, Pair b)
	{
		if(a.index1 == b.index1 || a.index1 == b.index2)
			return false;
		if(a.index2 == b.index1 || a.index2 == b.index2)
			return false;
		return true;
	}
	
	Dictionary<int,List<Pair>> GetDictionary(int[] nums)
	{		
		var dict = new Dictionary<int, List<Pair>>();
		for (int i = 0; i < nums.Length; i++)
		{
			for (int j = i+1; j < nums.Length; j++)
			{
				int currentSum = nums[i] + nums[j];
				var currentPair = new Pair(i , j);
				if(dict.ContainsKey(currentSum))
					dict[currentSum].Add(currentPair);
				else
					dict.Add(currentSum, new List<Pair>(){currentPair});
			}
		}
		return dict;
	}
}