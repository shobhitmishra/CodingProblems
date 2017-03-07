<Query Kind="Program" />

void Main()
{
	Console.WriteLine (IsUgly(14));
}

// Define other methods and classes here
public bool IsUgly(int num) 
{	
	while(num > 1 && num % 2 == 0)
		num = num / 2;
	while(num > 1 && num % 3 == 0)
		num = num / 3;
	while(num > 1 && num % 5 == 0)
		num = num / 5;
	return num == 1;
}