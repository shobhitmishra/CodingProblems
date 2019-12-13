from heapq import *
class MedianFinder:
    def __init__(self):
        # self.maxHeap stores the lower half and self.minHeap stores the upper half
        self.maxHeap, self.minHeap = [], []        

    def addNum(self, num: int) -> None:
        # try to add the number in self.maxHeap first
        if not self.maxHeap or -num >= self.maxHeap[0]:
            heappush(self.maxHeap, -num)
        else:
            heappush(self.minHeap, num)
        
        # if there are more elements than expected then balance
        if len(self.maxHeap) > len(self.minHeap) + 1:
            out = -heappop(self.maxHeap)
            heappush(self.minHeap, out)
        elif len(self.maxHeap) < len(self.minHeap):
            out = heappop(self.minHeap)
            heappush(self.maxHeap, -out)

    def findMedian(self) -> float:        
        if len(self.maxHeap) == len(self.minHeap):
            return (-self.maxHeap[0] + self.minHeap[0]) / 2
        
        return -self.maxHeap[0]


ob = MedianFinder()
ob.addNum(1)
print(ob.findMedian())
ob.addNum(2)
print(ob.findMedian())
ob.addNum(3)
print(ob.findMedian())