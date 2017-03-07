<Query Kind="Program" />

void Main()
{
	var ob = new Solution();
	var res = ob.RemoveDuplicateLetters("edebbed");
	res.Dump();
}

// Define other methods and classes here
public class Solution {
    public string RemoveDuplicateLetters(string s) 
	{
		if(string.IsNullOrEmpty(s))
			return s;
			
		Dictionary<char,int> lettersCount = new Dictionary<char,int>();
		Stack<char> letterStack = new Stack<char>();
		HashSet<char> used = new HashSet<char>();
		
		var charArr = s.ToCharArray();
		
		//Populate the dictionary first
		foreach (char c in charArr)
		{
			if(!lettersCount.ContainsKey(c))
				lettersCount.Add(c,0);
			lettersCount[c]++;
		}
        
		letterStack.Push(charArr[0]);
		used.Add(charArr[0]);
		lettersCount[charArr[0]]--;
		for (int i = 1; i < charArr.Length; i++)
		{
			char curr = charArr[i];
			lettersCount[curr]--;
			if(used.Contains(curr))			
				continue;
			
			while(letterStack.Count > 0 && curr <= letterStack.Peek() && lettersCount[letterStack.Peek()] > 0)
			{
				char ch = letterStack.Pop();				
				used.Remove(ch);
			}
			if(!used.Contains(curr))
			{
				letterStack.Push(curr);				
				used.Add(curr);
			}
		}
		
		var arr = letterStack.ToArray();
		Array.Reverse(arr);
		return new string(arr);
    }
}