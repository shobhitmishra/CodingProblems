<Query Kind="Program" />

void Main()
{
	var str = "";
	var ob = new Solution();	
	ob.RemoveDuplicateLetters(str).Dump();
}

// Define other methods and classes here
public class Solution
{
	public string RemoveDuplicateLetters(string s)
	{
		var arr = s.ToCharArray();
		var frequency = new Dictionary<char,int>();
		foreach (char ch in arr)
		{
			if(frequency.ContainsKey(ch) == false)
				frequency.Add(ch,0);
			frequency[ch] +=1;
		}
		
		var stack = new Stack<char>();
		var visited = new HashSet<char>();
		foreach (var ch in arr)
		{
			// reduce the frequency
			frequency[ch] -= 1;
			
			// if already in stack then continue
			if(visited.Contains(ch))
				continue;		

			// if stack is non empty, top is greater than current 
			// and frequency for top is not zero, pop
			while (stack.Count() != 0 && frequency[stack.Peek()] != 0 && stack.Peek() > ch)
			{
				var top = stack.Pop();
				visited.Remove(top);
			}
			visited.Add(ch);
			stack.Push(ch);
		}
		
		var result =  stack.Reverse().ToArray();
		return new string(result);
	}	
}