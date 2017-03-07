<Query Kind="Program" />

static long Limit = 1000000007;
//static StreamReader file = new StreamReader(@"D:\HackerRank\TestCases\SquareSubsequence_input.txt");
public static void Main()
{
	int numOfTestCases = Convert.ToInt32(Console.ReadLine().Trim());
	for (int i = 0; i < numOfTestCases; i++)
	{
		string input = Console.ReadLine().Trim();
		Console.WriteLine(GetNumOfSquareSubSequence(input));
	}
}

public static long GetNumOfSquareSubSequence(string input)
{
	long count = 0;
	for (int i = 1; i < input.Length; i++)
	{
		string str1 = input.Substring(0,i);
		string str2 = input.Substring(i);
		count += GetCommonSubsequences(str1, str2);
		count = count % Limit;
	}
	return count;
}

public static long GetCommonSubsequences(string str1, string str2)
{
	long[,] commonSubsequenceMatrix = new long[str1.Length, str2.Length];
	for (int j = 0; j < str2.Length; j++)
	{
		if(str1[0] == str2[0])
			commonSubsequenceMatrix[0,j] = 1;
	}
	for (int i = 1; i < str1.Length; i++)
	{
		if(str1[i] == str2[0])
			commonSubsequenceMatrix[i,0] = 1;
		commonSubsequenceMatrix[i,0] += commonSubsequenceMatrix[i-1,0];
	}
	for (int i = 1; i < str1.Length; i++)
	{
		for (int j = 1; j < str2.Length; j++)
		{
			commonSubsequenceMatrix[i,j] = commonSubsequenceMatrix[i-1,j] + 
				commonSubsequenceMatrix[i,j-1] - commonSubsequenceMatrix[i-1, j-1];
			if(str1[i] == str2[j])
				commonSubsequenceMatrix[i,j] += commonSubsequenceMatrix[i-1, j-1];
			commonSubsequenceMatrix[i,j] %= Limit;
		}
	}
	
	return commonSubsequenceMatrix[str1.Length -1, str2.Length -1];
}