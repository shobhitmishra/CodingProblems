<Query Kind="Program" />

void Main()
{
	var ob = new Solution();
	ob.Partition("a").Dump();
}

// Define other methods and classes here
public class Solution 
{
	public bool[,] GetPalindromeMatrix(string s)
	{
		bool[,] palindromeMatrix = new bool[s.Length, s.Length];
		for (int i = s.Length; i >= 0; i--)
		{
			for (int j = i; j < s.Length; j++)
			{
				if(s[i] == s[j] && (j-i <2 || palindromeMatrix[i+1, j-1]))
					palindromeMatrix[i,j] = true;
			}
		}
		return palindromeMatrix;
	}
	
	private List<int> GetTruePostions(bool[,] palindromeMatrix, int colNummber)	
	{
		var result = new List<int>();
		for (int i = 0; i <= colNummber; i++)
		{
			if(palindromeMatrix[i, colNummber])
				result.Add(i);
		}
		return result;
	}
	
    public IList<IList<string>> Partition(string s) 
	{
  		var palMatrix = GetPalindromeMatrix(s);
		var result = new List<IList<string>>[s.Length + 1];
		result[0] = new List<IList<string>>(){new List<string>()};
		
		for (int i = 0; i < s.Length; i++)
		{
			result[i+1] = new List<IList<string>>();			
			var truePositions = GetTruePostions(palMatrix, i);
			
			foreach (var pos in truePositions)
			{
				var palString = s.Substring(pos, i - pos + 1);
				
				var lists = result[pos];
				foreach (var list in lists)
				{
					var clone = new List<string>(list);
					clone.Add(palString);
					result[i+1].Add(clone);
				}
			}
		}
		return result[s.Length];
    }
}