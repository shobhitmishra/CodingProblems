<Query Kind="Program" />

public static void Main()
{
	int numOfTest = Convert.ToInt32(Console.ReadLine().Trim());
	for (int i = 0; i < numOfTest; i++)
	{
		var str1 = Console.ReadLine();
		var str2 = Console.ReadLine();
		if(IsCommonSubstr(str1, str2))
			Console.WriteLine("YES");
		else
			Console.WriteLine("NO");
	}
}

public static bool IsCommonSubstr(string str1, string str2)
{
	var str1Hash = new HashSet<char>(str1.ToCharArray());	
	str1Hash.IntersectWith(str2);
	return str1Hash.Count >= 1;
}
