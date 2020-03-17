from typing import List
from collections import Counter
import heapq
from collections import deque
class Solution:
    def leastInterval(self, tasks: List[str], n: int) -> int:
        freqTuple = [(-freq, ch) for ch, freq in Counter(tasks).items()]        
        intervalCount = 0       

        while freqTuple:
            waiting = []
            k = n + 1
            while freqTuple and k:
                intervalCount += 1
                k -= 1

                if freqTuple:
                    freq, ch = heapq.heappop(freqTuple)
                    waiting.append((freq +1, ch))            
           
            # append all the waiting ones back
            for freq, ch in waiting:
                if freq != 0:
                    heapq.heappush(freqTuple, (freq, ch))

            # if there are still items to be processed then add the idle time
            if freqTuple:
                intervalCount += k

        return intervalCount
        

tasks = "a a a b b b".split()
n = 2
ob = Solution()
print(ob.leastInterval(tasks, n))

