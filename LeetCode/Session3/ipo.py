from heapq import *
from typing import List 
class Solution:
    def findMaximizedCapital(self, k: int, wealth: int, profits: List[int], capitals: List[int]) -> int:
        minCapitalHeap, maxProfitHeap = [], []
        for i in range(len(capitals)):
            heappush(minCapitalHeap, (capitals[i], profits[i]))
        
        for _ in range(k):
            # find the projects which require less capital than available wealth
            while minCapitalHeap and minCapitalHeap[0][0] <= wealth:
                _, profit = heappop(minCapitalHeap)
                heappush(maxProfitHeap, -profit)
            
            if not maxProfitHeap:
                break

            wealth += -heappop(maxProfitHeap) 
        
        return wealth

k=0
W=0
Profits=[1,2,3,5]
Capital=[0,1,2,3]
ob = Solution()
print(ob.findMaximizedCapital(k, W, Profits, Capital))

            