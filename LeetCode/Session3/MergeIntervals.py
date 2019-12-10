from typing import List
class Solution:
    def merge(self, intervals: List[List[int]]) -> List[List[int]]:
        if not intervals:
            return []
        intervals.sort(key = lambda interval: interval[0])
        result = []
        start, end = intervals[0][0], intervals[0][1]

        for i in range(1, len(intervals)):            
            currStart, currEnd = intervals[i][0], intervals[i][1]
            # if overlapping, adjust the end
            if currStart <= end:
                end = max(end, currEnd)
            else:
                result.append([start, end])
                start, end = currStart, currEnd
        result.append([start, end])
        return result

intervals = [[1,3]]
ob = Solution()
print(ob.merge(intervals))

        