<Query Kind="Program" />

void Main()
{
	var ob = new Solution();
	ob.Generate(7).Dump();
}

// Define other methods and classes here
public class Solution
{
	public IList<IList<int>> Generate(int numRows)
	{
		var result = new List<IList<int>>();
		if(numRows < 1)
			return result;

		var tempList = new List<int> { 1};
		result.Add(tempList);
		
		for (int i = 1; i < numRows; i++)
		{
			var currResult = new List<int>() {1};
			for(int j = 1; j < tempList.Count; j++)
				currResult.Add(tempList[j] + tempList[j-1]);
			currResult.Add(1);
			result.Add(currResult);
			tempList = currResult;
		}
		
		return result;
	}
}