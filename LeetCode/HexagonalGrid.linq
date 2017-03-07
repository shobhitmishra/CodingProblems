<Query Kind="Program" />

public static void Main()
{
	int numOfTestCases = Convert.ToInt32(Console.ReadLine().Trim());
	for (int i = 0; i < numOfTestCases; i++)
	{
		Console.WriteLine(IsFillingPossible() == true ? "YES" : "NO");
	}
}

public static bool IsFillingPossible()
{
	int GridWidth = Convert.ToInt32(Console.ReadLine().Trim());
	int[] input = new int[2*GridWidth];
	string line1 = Console.ReadLine().Trim();
	string line2 = Console.ReadLine().Trim();
	for (int i = 0; i < GridWidth; i++)
	{
		input[2*i] = Convert.ToInt32(line1[i] - '0');
		input[2*i + 1] = Convert.ToInt32(line2[i] - '0');
	}
	return IsFillingPossibleHelper(input);
}

public static bool IsFillingPossibleHelper(int[] input)
{
	for (int i = 0; i < input.Length; i++)
	{
		if(input[i] == 0)
		{
			if(i > 0 && input[i - 1] == 0)			
				input[i -1] = input[i] = 2;			
			else if((i+1)<input.Length && input[i + 1] == 0)
				input[i] = input[i+1] = 2;
			else if((i+2)<input.Length && input[i+2] == 0)
				input[i] = input[i + 2] = 2;
			else
				return false;
		}
	}
	return true;
}
