<Query Kind="Program" />

void Main()
{
	var ob = new Solution();
	ob.GenerateTrees(3).Dump();
}

// Define other methods and classes here
public class TreeNode
{
	public int val;
	public TreeNode left;
	public TreeNode right;
	public TreeNode(int x) { val = x; }
}

public class Solution
{
	public IList<TreeNode> GenerateTrees(int n)
	{
		if(n < 1)
			return new List<TreeNode>();
		return GenerateTreesHelper(1,0);		 
	}
	
	private IList<TreeNode> GenerateTreesHelper(int start, int end)
	{
		var result = new List<TreeNode>();
		
		if(start > end)
			result.Add(null);	
		else if(start == end)
			result.Add(new TreeNode(start));
		else
		{
			for (int i = start; i <= end; i++)
			{
				var leftTrees = GenerateTreesHelper(start, i -1);
				var rightTrees = GenerateTreesHelper(i+1, end);
				
				foreach (var leftTree in leftTrees)
				{
					foreach (var rightTree in rightTrees)
					{
						var tree = new TreeNode(i);
						tree.left = leftTree;
						tree.right = rightTree;
						result.Add(tree);
					}
				}
			}
		}		
		return result;		
	}
	
	//Dictionary<int, List<TreeNode>> memoized = new Dictionary<int, List<TreeNode>>();
//	public IList<TreeNode> GenerateTrees(int n)
//	{
//		var results = new List<TreeNode>();
//		for (int i = 1; i <= n; i++)
//		{
//			var treesAti = GetTreeRootedAtVal(i, 1, n);
//			results.AddRange(treesAti);
//		}
//		return results;		
//	}
//	
//	private List<TreeNode> GetTreeRootedAtVal(int val, int start, int end)
//	{		
//		var result = new List<TreeNode>();		
//		var leftResults = new List<TreeNode>();
//		
//		if(val <= start)
//			leftResults.Add(null);
//		else
//		{
//			for (int i = start; i < val; i++)
//			{
//				var temp = GetTreeRootedAtVal(i, start, val - 1);
//				leftResults.AddRange(temp);
//			}
//		}
//		
//		var rightResults = new List<TreeNode>();
//		
//		if(val >= end)
//			rightResults.Add(null);
//		else
//		{
//			for (int i = val + 1; i <= end; i++)
//			{
//				var temp = GetTreeRootedAtVal(i, val + 1, end);
//				rightResults.AddRange(temp);
//			}
//		}
//		
//		foreach (var leftTRee in leftResults)
//		{
//			foreach (var rightTree in rightResults)
//			{
//				var tree = new TreeNode(val);
//				tree.left = leftTRee;
//				tree.right = rightTree;
//				result.Add(tree);
//			}			
//		}
//		
//		return result;
//	}
}