from heapq import *
class Interval:
    def __init__(self, start, end):
        self.start = start
        self.end = end

class Solution:
    def employeeFreeTime(self, schedule: 'list<list<Interval>>') -> 'list<Interval>':
        if not schedule:
            return []
        heap = []
        for emp in schedule:
            for interval in emp:
                heappush(heap, (interval.start, interval.end))
        
        _, end = heappop(heap)
        result = []
        while len(heap) > 0:
            currStart, currEnd = heappop(heap)
            if currStart > end:
                result.append(Interval(end, currStart))
                end = currEnd
            else:
                end = max(end, currEnd)
        return result

scheduleList = [[[1,3],[6,7]],[[2,4]],[[2,5],[9,12]]]
schedule = []
for _, empSchedule in enumerate(scheduleList):
    empIntervals = []
    for _, sch in enumerate(empSchedule):
        empInterval = Interval(sch[0], sch[1])
        empIntervals.append(empInterval)
    schedule.append(empIntervals)
ob = Solution()
result = ob.employeeFreeTime(schedule)
print(result)
        
        
        