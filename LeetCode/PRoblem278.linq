<Query Kind="Program" />

void Main()
{
	var ob = new Solution();
	ob.badVersion = 5;
	for (int i = 5; i < 100; i++)
	{
		ob.FirstBadVersion(12).Dump();
	}
}

public class VersionControl
{
	public int badVersion;
	public bool IsBadVersion(int n)
	{
		return (n >= badVersion);
	}
}
// Define other methods and classes here
public class Solution : VersionControl
{
	public int FirstBadVersion(int n)
	{
		int start = 0;
		int end = n;
		while (start < end)
		{
			int mid = start + (end - start) / 2;
			if (IsBadVersion(mid) == false)
				start = mid + 1;			
			else
				end = mid;
		}
		return start;
	}
}