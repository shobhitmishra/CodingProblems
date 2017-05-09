<Query Kind="Program" />

void Main()
{
	var ob = new Solution();
	var num = 1000000000;
	ob.NumberToWords(num).Dump();
}

// Define other methods and classes here
public class Solution
{	
	string hun = "Hundred";
	string thou = "Thousand";
	string mil = "Million";
	string bil = "Billion";
	public string NumberToWords(int num)
	{
		if(num == 0)
			return "Zero";
		var billion = 1000000000;
		var million = 1000000;
		var thousand = 1000;
		var result = "";
		// Get the billionth part
		var bi = num / billion;
		if (bi > 0)
		{
			var billionString = ConvertAthreeDigitNumtoWords(bi);
			result = $"{billionString} {bil}";
		}
		
		// Get the million part
		num = num % billion;
		if(num == 0)
			return result;
		var mi = num / million;
		if (mi > 0)
		{
			var millionString = ConvertAthreeDigitNumtoWords(mi);
			result = AddASpace(result);
			result += $"{millionString} {mil}";
		}
		
		// Get the thousand part
		num = num % million;
		if(num == 0)
			return result;
		var th = num / thousand;
		if (th > 0)
		{
			var thousandString = ConvertAthreeDigitNumtoWords(th);
			result = AddASpace(result);
			result += $"{thousandString} {thou}";
		}

		// Get the rest
		num = num % thousand;
		if (num > 0)
		{
			result = AddASpace(result);
			result += ConvertAthreeDigitNumtoWords(num);
		}
		
		return result;
	}
	private string AddASpace(string result)
	{
		if(string.IsNullOrEmpty(result) == false)
			return result + " ";
		return "";
	}
	private string ConvertAthreeDigitNumtoWords(int num)
	{
		var result = "";
		if(num == 0)
			return result;
		var dict = GetCommonConversions();
		var hundredThPart = num / 100;
		if (hundredThPart > 0)
		{
			result = $"{dict[hundredThPart]} {hun}";	
		}
		num = num % 100;
		if(num == 0)
			return result;
		if (num > 0 && num < 20)
		{
			result = AddASpace(result);
			result += $"{dict[num]}";
			return result;
		}
		
		var digit = num % 10;
		num = num - digit;
		
		result = AddASpace(result);
		result += $"{dict[num]}";
		
		if (digit > 0)
		{
			result = AddASpace(result);
			result += $"{dict[digit]}";
		}
		return result;
	}
	
	private Dictionary<int,string> GetCommonConversions()
	{
		var dict = new Dictionary<int,string>();
		dict.Add(1, "One");
		dict.Add(2, "Two");
		dict.Add(3, "Three");
		dict.Add(4, "Four");
		dict.Add(5, "Five");
		dict.Add(6, "Six");
		dict.Add(7, "Seven");
		dict.Add(8, "Eight");
		dict.Add(9, "Nine");
		dict.Add(10, "Ten");
		dict.Add(11, "Eleven");
		dict.Add(12, "Twelve");
		dict.Add(13, "Thirteen");
		dict.Add(14, "Fourteen");
		dict.Add(15, "Fifteen");
		dict.Add(16, "Sixteen");
		dict.Add(17, "Seventeen");
		dict.Add(18, "Eighteen");
		dict.Add(19, "Nineteen");
		dict.Add(20, "Twenty");
		dict.Add(30, "Thirty");
		dict.Add(40, "Forty");
		dict.Add(50, "Fifty");
		dict.Add(60, "Sixty");
		dict.Add(70, "Seventy");
		dict.Add(80, "Eighty");
		dict.Add(90, "Ninety");
		return dict;
	}
}