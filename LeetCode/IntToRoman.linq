<Query Kind="Program" />

void Main()
{
	var ob = new Solution();
	for (int i = 0; i < 100; i++)
	{
		Console.Write(ob.IntToRoman(i) + "\t");
		if(i > 0 && i % 10 == 0)
			Console.WriteLine ();
	}
}

// Define other methods and classes here
public class Solution 
{
	Number[] numArr = new Number[8];
	public class Number
	{		
		public int number;
		public string numeral;
		public Number(int number, string numeral)
		{
			this.number = number;
			this.numeral = numeral;
		}
	}
    public string IntToRoman(int num) 
	{
        numArr[1] = new Number(1,"I");
		numArr[2] = new Number(5,"V");
		numArr[3] = new Number(10,"X");
		numArr[4] = new Number(50,"L");
		numArr[5] = new Number(100,"C");
		numArr[6] = new Number(500,"D");
		numArr[7] = new Number(1000,"M");
		
		return IntToRomanHelper(num);
    }
	
	public string IntToRomanHelper(int num)
	{
		string result = "";
		if(num <= 0)
			return result;
		
		int divisor = 1;
		while(divisor * 10 <= num)
			divisor *= 10;
			
		int firstDigit = num / divisor;
		int smallerThanNIndex = GetSmallerThanN(num);
		int remaining = 0;
		
		if(firstDigit == 4)
		{
			result = numArr[smallerThanNIndex].numeral + numArr[smallerThanNIndex + 1].numeral;
			remaining = num - 4 *divisor;
		}
		else if(firstDigit == 9)
		{
			result = numArr[smallerThanNIndex -1].numeral + numArr[smallerThanNIndex + 1].numeral;		
			remaining = num - 9 *divisor;
		}
		else
		{			
			result += numArr[smallerThanNIndex].numeral;
			remaining = num - numArr[smallerThanNIndex].number;
		}
		
		result += IntToRomanHelper(remaining);
		return result;
	}
	
	int GetSmallerThanN(int num)
	{
		int i = 1;
		if(num >= 1000)
			return numArr.Length - 1;
		while(numArr[i].number <= num)
		 	i++;
		return i -1;
	}
}