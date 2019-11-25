from typing import List
import heapq
class Solution:
    def minMeetingRooms(self, intervals: List[List[int]]) -> int:
        intervals.sort(key = lambda x : x[0])
        maxRooms = 0
        meetingEndTimes = []
        for _, interval in enumerate(intervals):
            start, end = interval[0], interval[1]
            while len(meetingEndTimes) > 0 and start >= meetingEndTimes[0]:
                heapq.heappop(meetingEndTimes)
            heapq.heappush(meetingEndTimes, end)
            maxRooms = max(maxRooms, len(meetingEndTimes))
        return maxRooms

intervals = [[0, 30],[5, 10],[15, 20], [1,10]]
ob = Solution()
print(ob.minMeetingRooms(intervals))