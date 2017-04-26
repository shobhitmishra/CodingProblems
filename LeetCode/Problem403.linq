<Query Kind="Program" />

void Main()
{
	var input = new int[] { 0,1,2,3,4,5,6,7,8,9,10,11};
	var ob = new Solution();
	ob.CanCross(input).Dump();
}

// Define other methods and classes here
public class Solution
{
	public bool CanCross(int[] stones)
	{
		if(stones[1] != 1)
			return false;
		
		var cumDist = new Dictionary<int,int>();		
		var lastIndex = stones.Length - 1;
		var dist = new HashSet<int>[stones.Length];
		for (int i = 0; i <= lastIndex; i++)
		{
			dist[i] = new HashSet<int>();
			cumDist.Add(stones[i], i);
		}		
		dist[1].Add(1);
		
		// at every position, keep track of the possible previous distances to reach here
		for (int i = 1; i < lastIndex; i++)
		{
			var possibleDistances = dist[i];
			var curr = stones[i];
			foreach (var distance in possibleDistances)
			{
				int next = 0;
				// try distance - 1
				if (distance - 1 > 0)
				{
					next = curr + distance - 1;									
					// find index of next
					if(cumDist.ContainsKey(next))
						dist[cumDist[next]].Add(distance - 1);
				}

				// try distance
				next = curr + distance;							
				if (cumDist.ContainsKey(next))
					dist[cumDist[next]].Add(distance);

				// try distance + 1
				next = curr + distance + 1;
				if (cumDist.ContainsKey(next))
					dist[cumDist[next]].Add(distance + 1);
				if(dist[lastIndex].Count > 0)
					return true;
			}
		}
		//dist.Dump();
		return dist[lastIndex].Count > 0;
	}
	
}