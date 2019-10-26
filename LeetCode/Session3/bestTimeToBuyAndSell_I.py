from typing import List
class Solution:
    def maxProfit(self, prices: List[int]) -> int:
        if not prices:
            return 0
        maxProfit = 0
        minSoFar = prices[0]
        for i in range(len(prices)):
            current = prices[i]
            maxProfit = max(maxProfit, current - minSoFar)
            minSoFar = min(minSoFar, current)
        return maxProfit

prices = [7,1,5,3,6,4]
ob = Solution()
print(ob.maxProfit(prices))