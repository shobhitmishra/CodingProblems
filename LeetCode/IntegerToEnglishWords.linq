<Query Kind="Program" />

void Main()
{
	Console.WriteLine (NumberToWords(1000000));
}

// Define other methods and classes here
public string NumberToWords(int num) {
	string result = "";
	if(num == 0)
		return "Zero";
	string numAsString = num.ToString();
	// We need to split the word into groups of three
	List<string> triplets = GetTriplets(numAsString);
	for (int i = 0; i < triplets.Count; i++)
	{
		string tripletInWords = TripletInWords(triplets[i]);
		if(!string.IsNullOrEmpty(tripletInWords))
			tripletInWords += GetCorrectUnit(i);
		result =  tripletInWords + result;
	}	
	result = result.Trim();
	return result;
}

private static string GetCorrectUnit(int position)
{
	switch(position)
	{
		case 0:
			return "";
		case 1:
			return " Thousand ";
		case 2:
			return " Million ";
		case 3:
			return " Billion ";
	}
	return "";
}
private static string ConvertTwoDigitsToNums(string num)
{
	if(num.Length > 2 || num.Length == 0)
		throw new ArgumentOutOfRangeException("num is not correct");
	if(num[0] == '1')
		return TensConversion(num);
	else
	{
		string result = "";
		string decimalString = DecimalPositionConversion(num[0]);
		if(!string.IsNullOrEmpty(decimalString))
			decimalString = decimalString + " ";
		result = decimalString + UnitPositionConversion(num[1]);
		result = result.Trim();
		return result;
	}
}

private static string TripletInWords(string triplet)
{
	string result ="";
	if(triplet.Length > 3 || triplet.Length == 0)
		throw new ArgumentOutOfRangeException("triplet is not correct");
	if(triplet.Length == 1)
		return UnitPositionConversion(triplet[0]);
	
	string lastTwoDigits = "";
	if(triplet.Length == 3)
	{
		string hundred = UnitPositionConversion(triplet[0]);
		if(!string.IsNullOrEmpty(hundred))
			hundred = hundred + " " + "Hundred ";
		result = hundred;
		lastTwoDigits = triplet.Substring(1,2);
	}
	else if (triplet.Length == 2)
		lastTwoDigits = triplet;
	
	result += ConvertTwoDigitsToNums(lastTwoDigits);
	result.Trim();
	return result;
}

private static string UnitPositionConversion(char digit)
{
	switch(digit)
	{
		case '0':
			return string.Empty;
		case '1':
			return "One";
		case '2':
			return "Two";
		case '3':
			return "Three";
		case '4':
			return "Four";
		case '5':
			return "Five";
		case '6':
			return "Six";
		case '7':
			return "Seven";
		case '8':
			return "Eight";
		case '9':
			return "Nine";
		default:
			throw new ArgumentOutOfRangeException(digit + " can't be converted");
	}
}

private static string DecimalPositionConversion(char digit)
{
	switch(digit)
	{
		case '0':
			return string.Empty;;		
		case '2':
			return "Twenty";
		case '3':
			return "Thirty";
		case '4':
			return "Forty";
		case '5':
			return "Fifty";
		case '6':
			return "Sixty";
		case '7':
			return "Seventy";
		case '8':
			return "Eighty";
		case '9':
			return "Ninety";
		default:
			throw new ArgumentOutOfRangeException(digit + " can't be converted");
	}
}
private static string TensConversion(string digit)
{
	switch(digit)
	{
		case "10":
			return "Ten";		
		case "11":
			return "Eleven";
		case "12":
			return "Twelve";
		case "13":
			return "Thirteen";
		case "14":
			return "Fourteen";
		case "15":
			return "Fifteen";
		case "16":
			return "Sixteen";
		case "17":
			return "Seventeen";
		case "18":
			return "Eighteen";
		case "19":
			return "Nineteen";
		default:
			throw new ArgumentOutOfRangeException(digit + " can't be converted");
	}
}

private static List<string> GetTriplets(string numAsString)
{
	List<string> triplets = new List<string>();
	int tripletCount = numAsString.Length / 3;
	int i = 1;
	while(i <= tripletCount)
	{
		string tempString = numAsString.Substring(numAsString.Length - i * 3, 3);
		triplets.Add(tempString);
		i++;
	}
	string remainingString = numAsString.Substring(0, numAsString.Length - tripletCount * 3);
	if(!string.IsNullOrEmpty(remainingString))
		triplets.Add(remainingString);
	return triplets;
}

