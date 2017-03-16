<Query Kind="Program" />

void Main()
{
	string preOrder = "7,2,#,2,#,#,#,6,#";
	var ob = new Solution();
	ob.IsValidSerialization(preOrder).Dump();
}

// Define other methods and classes here
public class Solution
{
	public bool IsValidSerialization(string preorder)
	{
		if(string.IsNullOrEmpty(preorder))
			return true;
		string[] nodes = preorder.Split(',');		
		int degree = 1;		
		// anytime you encounter a non null, increase degree 
		// anytime you encounter null, decrease degree
		foreach (var item in nodes)
		{
			if (--degree < 0) return false;			
			if(item != "#")
				degree +=2;
		}		
		return degree == 0;
	}
}