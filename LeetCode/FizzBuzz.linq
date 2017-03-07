<Query Kind="Program" />

static void Main(string[] args)
{
   using (StreamReader reader = File.OpenText(args[0]))
   {
		while (!reader.EndOfStream)
		{
			string line = reader.ReadLine();
			if (null == line)
				continue;
			// do something with line
			PrintFizzBuzz(line);
		}
   }
	//PrintFizzBuzz("2 7 15");
}
// Define other methods and classes here
public static int[] ProcessInput(string line)
{
	var strs = line.Trim().Split();
	List<int> output = new List<int>();
	foreach (var element in strs)
	{
		output.Add(Convert.ToInt32(element));
	}
	return output.ToArray();
}
public static void PrintFizzBuzz(string line)
{
	var input = ProcessInput(line);
	int firstNum = input[0];
	int secondNum = input[1];
	int limit = input[2];
	string output = "";
	for (int i = 1; i <= limit; i++)
	{
		if(i % firstNum == 0 && i % secondNum == 0)
			output = Addtooutput(output, "FB");
		else if(i % firstNum == 0)
			output = Addtooutput(output, "F");
		else if(i % secondNum == 0)
			output = Addtooutput(output, "B");
		else
			output = Addtooutput(output, i.ToString());
	}
	System.Console.WriteLine(output);
}
public static string Addtooutput(string output, string toadd)
{
	if(string.IsNullOrEmpty(output))
		return toadd;
	return output + " " + toadd;
}