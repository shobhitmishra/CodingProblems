from typing import List
class Solution:
    def insert(self, intervals: List[List[int]], newInterval: List[int]) -> List[List[int]]:
        # find where to insert
        insertPostion = 0        
        while insertPostion < len(intervals) and intervals[insertPostion][1] < newInterval[0]:
            insertPostion +=1
        if insertPostion == len(intervals):
            intervals.append(newInterval)
            return intervals

        result = intervals[:insertPostion]
        start, end = newInterval[0], newInterval[1]
        i = insertPostion
        while i < len(intervals):
            currStart, currEnd = intervals[i][0], intervals[i][1]
            # merge if overlapping
            if currStart > end:
                break
            else:
                start = min(start, currStart)
                end = max(end, currEnd)
                i += 1
        result.append([start, end])
        result.extend(intervals[i:])
        return result
        
intervals = []
newInterval = [1,3]
ob = Solution()
print(ob.insert(intervals, newInterval))


