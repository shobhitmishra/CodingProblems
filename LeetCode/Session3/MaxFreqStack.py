import heapq
from collections import defaultdict
class FreqStack:
    def __init__(self):
        self.heap = []
        self.numCount = 0
        self.freqMap = defaultdict(int)

    def push(self, x: int) -> None:
        self.numCount += 1
        self.freqMap[x] += 1
        item = (-self.freqMap[x], -self.numCount, x)
        heapq.heappush(self.heap, item)

    def pop(self) -> int:
        freq, _, num = heapq.heappop(self.heap)
        freq = -freq
        self.freqMap[num] -= 1
        return num

operations = ["push","push","push","push","push","push","pop","pop","pop","pop"]
inputs = [[5],[7],[5],[7],[4],[5],[],[],[],[]]
operationTuple = zip(operations, inputs)
ob = FreqStack()
for item in operationTuple:
    if item[0] == 'push':
        numtoPush = item[1][0]
        ob.push(numtoPush)
    else:
        print(ob.pop())