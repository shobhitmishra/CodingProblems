import heapq
class Interval:
    def __init__(self, start, end):
        self.start = start
        self.end = end
class Solution:
    def employeeFreeTime(self, schedule: 'list<list<Interval>>') -> 'list<Interval>':        
        if not schedule:
            return []
        
        minHeap = []
        for index, emp in enumerate(schedule):
            heapq.heappush(minHeap, (emp[0].start, emp[0].end, index, 0))       

        result = []
        prevEnd = minHeap[0][1]
        while len(minHeap) > 0:
            minItem = heapq.heappop(minHeap)            
           
            if prevEnd < minItem[0]:
                result.append(Interval(prevEnd, minItem[0]))
                prevEnd = minItem[1]
            else:
                prevEnd = max(prevEnd, minItem[1])
            
            listidx, itemidx = minItem[2], minItem[3]
            empsch = schedule[listidx]
            if itemidx < len(empsch) -1:                
                heapq.heappush(minHeap, (empsch[itemidx+1].start, empsch[itemidx+1].end, listidx, itemidx+1))       
           
        return result

scheduleList = [[[45, 56], [89, 96]], [[5,21], [57,74]]]
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