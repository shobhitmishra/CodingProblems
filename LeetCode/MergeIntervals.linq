<Query Kind="Program" />

void Main()
{
	var input = new List<Interval>() 
	{
		new Interval(1,4),
		new Interval(2,3),
//		new Interval(6,10),
//		new Interval(10,18)
	};
	var ob = new Solution();
	ob.Merge(input).Dump();
}

// Define other methods and classes here
public class Interval {
    public int start;
    public int end;
    public Interval() { start = 0; end = 0; }
    public Interval(int s, int e) { start = s; end = e; }
}

public class Solution {
    public IList<Interval> Merge(IList<Interval> intervals) 
	{
        var sortedIntervals = intervals.OrderBy(x => x.start);
		var mergedIntervals = new List<Interval>();
		foreach (var interval in sortedIntervals)
		{
			MergeWithLastInterval(interval, mergedIntervals);
		}
		
		return mergedIntervals;
    }
	
	public void MergeWithLastInterval(Interval interval, List<Interval> mergedIntervals)
	{
		int count = mergedIntervals.Count();
		var lastInterval = count == 0 ? null : mergedIntervals[count-1];
		if(lastInterval == null)
			mergedIntervals.Add(interval);
		else
		{
			if(IsOverlapping(interval,lastInterval))
			{
				var temp = new Interval(lastInterval.start, Math.Max(lastInterval.end, interval.end));
				mergedIntervals[count-1] = temp;
			}
			else
				mergedIntervals.Add(interval);
		}
	}
	
	//interval2 will have alower start time that interval1
	private bool IsOverlapping(Interval interval1, Interval interval2)
	{
		return interval1.start <= interval2.end;
	}
}