from typing import List
import bisect
class Solution:
    def findRightInterval(self, intervals: List[List[int]]) -> List[int]:
        sortedStart = sorted([[x[0], index] for index, x in enumerate(intervals)]) + [[float('inf'), -1]]
        # do binary search for the right position in the sorted start 
        result = []
        for interval in intervals:
            endTime = interval[1]
            position = bisect.bisect(sortedStart, [endTime])
            result.append(sortedStart[position][1])
        return result

input = [ ]
ob = Solution()
print(ob.findRightInterval(input))