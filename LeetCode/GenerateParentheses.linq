<Query Kind="Program" />

void Main()
{
	var ob = new Solution();
	for (int i = 0; i < 5; i++)
	{
		var result = ob.GenerateParenthesis(i);
		result.Dump();
	}
}

// Define other methods and classes here
public class Solution 
{
    public IList<string> GenerateParenthesis(int n) 
	{
        if(n == 0)
			return new List<string>();
		HashSet<string> result = new HashSet<string>(){"()"};
		for (int i = 2; i <= n; i++)
		{
			var temp = new HashSet<string>();
			foreach (string element in result)
			{
				// Add () in the end
				temp.Add(element + "()");
				// wrap the element in (...)
				temp.Add("(" + element + ")");
				//append () in the beginning 
				temp.Add("()" + element);
				
			}
			result = temp;
		}
		
		var resultList = result.ToList();
		resultList.Sort();
		return resultList;
    }
}