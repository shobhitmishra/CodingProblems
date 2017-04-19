<Query Kind="Program" />

void Main()
{
	var str = "/home//foo/";
	var ob = new Solution();
	ob.SimplifyPath(str).Dump();
}

// Define other methods and classes here
public class Solution
{
	public string SimplifyPath(string path)
	{
		var splitPath = path.Split('/');
		var nonEmptySplitPath = splitPath.Where(x => !string.IsNullOrWhiteSpace(x));
		
		var pathStack = new Stack<string>();
		foreach (var pathElement in nonEmptySplitPath)
		{
			if(pathElement == ".")
				continue;
			if (pathElement == "..")
			{
				if(pathStack.Count > 0)
					pathStack.Pop();
			}
			else
				pathStack.Push(pathElement);
		}
		
		var resultPath = "/" + string.Join("/",pathStack.Reverse());
		return resultPath;
	}
}