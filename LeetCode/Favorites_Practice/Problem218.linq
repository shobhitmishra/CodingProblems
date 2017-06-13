<Query Kind="Program" />

void Main()
{
	var input = new int[,] { {2,9,10}, {3,7,15}, {5,12,12}, {15,20,10}, {19,24,8}};
	var ob = new Solution();
	ob.GetSkyline(input).Dump();
}

// Define other methods and classes here
public class Solution
{
	public IList<int[]> GetSkyline(int[,] buildings)
	{
		var input = new List<Point>();
		for (int i = 0; i < buildings.GetLength(0); i++)
		{
			var startPoint = new Point(buildings[i,0], -buildings[i,2]);
			var endPoint = new Point(buildings[i,1], buildings[i,2]);
			input.Add(startPoint);
			input.Add(endPoint);
		}
		var sortedInput = input.OrderBy(p => p.x).ThenBy(p => p.height).ToArray();
		var result = GetSkylineHelper(sortedInput);
		return result;
	}
	
	private IList<int[]> GetSkylineHelper(Point[] sortedInput)
	{
		var result = new List<Point>();
		var htDict = new Dictionary<int,List<Point>>();
		var maxHeight = 0;
		// We need to add points to result wheneever we add/remove point of max height
		foreach (var point in sortedInput)
		{
			// Add it if it is start point and remove it if it is end point
			if (point.height < 0)
			{
				var ht = Math.Abs(point.height);
				if(htDict.ContainsKey(ht) == false)
					htDict.Add(ht, new List<Point>());
				htDict[ht].Add(point);
				if (ht > maxHeight)
				{
					maxHeight = ht;
					result.Add(new Point(point.x, ht));
				}
			}
			else
			{
				var htList = htDict[point.height];
				htList.RemoveAt(0);
				if (htList.Any() == false)
				{
					htDict.Remove(point.height);
					if (maxHeight == point.height)
					{
						maxHeight = htDict.Keys.Any() ? htDict.Keys.Max() : 0;
						result.Add(new Point(point.x,maxHeight));
					}
				}
			}
		}
		//result.Dump();
		return result.Select(x => new int[] {x.x, x.height}).ToArray();
	}
}


public class Point
{
	public int x;
	public int height;
	// negative height indicates building start
	public Point(int xCoord, int ht)
	{
		x = xCoord;
		height = ht;
	}
}