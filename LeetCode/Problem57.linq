<Query Kind="Program" />

void Main()
{
	var input1 = new List<Interval>()
	{
	new Interval(1,2),
	new Interval(3,5),
	new Interval(6,7),
	new Interval(8,10),
	new Interval(12,16)
	};
	var input2 = new Interval(4,9);
	var ob = new Solution();
	ob.Insert(input1, null);
	input1.Dump();
}

// Define other methods and classes here
public class Interval {
    public int start;
    public int end;
    public Interval() { start = 0; end = 0; }
    public Interval(int s, int e) { start = s; end = e; }
}

public class Solution
{
	public IList<Interval> Insert(IList<Interval> intervals, Interval newInterval)
	{
		if(newInterval == null)
			return intervals;
		if (intervals == null || intervals.Count == 0)
			return new List<Interval>() { newInterval};
		
		var result = new List<Interval>(intervals);
		// insert at the right position
		int i = 0;
		while (i < result.Count)
		{
			if(result[i].start > newInterval.start)
				break;
			i++;
		}
		result.Insert(i,newInterval);
		
		MergeIntervals(result);
		return result;
	}
	
	private void MergeIntervals(IList<Interval> intervals)
	{
		for (int i = 0; i < intervals.Count -1; i++)
		{
			var current = intervals[i];
			var next = intervals[i + 1];
			if (current.start <= next.start && next.start <= current.end)
			{
				// merge two intervals
				var newInterval = new Interval(Math.Min(current.start, next.start),
				Math.Max(current.end, next.end));
				intervals.RemoveAt(i+1);
				intervals.RemoveAt(i);
				intervals.Insert(i,newInterval);
				MergeIntervals(intervals);
			}
		}
	}
}