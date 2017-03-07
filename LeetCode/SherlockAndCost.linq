<Query Kind="Program" />

public static void Main()
{
	int numOfTestCases = Convert.ToInt32(Console.ReadLine().Trim());
	for (int i = 0; i < numOfTestCases; i++)
	{
		Console.ReadLine();
		int[] numbers = Console.ReadLine().Trim().Split().Select(x => Convert.ToInt32(x)).ToArray();
		Console.WriteLine(GetMaxSum(numbers));
	}
}

public static long GetMaxSum(int[] numbers)
{
	long[,] solution = new long[numbers.Length,2];
	solution[0,0] = solution[0,1] = 0;
	for (int i = 1; i < numbers.Length; i++)
	{
		solution[i,0] = Math.Max(solution[i-1,0], solution[i-1,1] + numbers[i-1] - 1);
		solution[i,1] = Math.Max(solution[i-1,1],solution[i-1,0] + numbers[i] - 1);
	}
	return Math.Max(solution[numbers.Length -1, 0], solution[numbers.Length -1, 1]);
}
