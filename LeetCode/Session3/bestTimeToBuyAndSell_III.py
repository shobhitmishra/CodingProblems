from typing import List
class Solution:
    def maxProfit(self, prices: List[int]) -> int:
        if not prices:
            return 0        
        minSoFar = prices[0]        
        leftToRightMaxProfit = [0] * len(prices)
        for i in range(1, len(prices)):
            current = prices[i]            
            minSoFar = min(minSoFar, current)
            leftToRightMaxProfit[i] = max(leftToRightMaxProfit[i-1], current - minSoFar)

        maxProfit = 0
        maxSoFar = prices[-1]
        rightToLeftMaxProfit = [0] * len(prices)
        for i in range(len(prices)-2, -1, -1):
            current = prices[i]
            maxSoFar = max(maxSoFar, current)
            rightToLeftMaxProfit[i] = max(rightToLeftMaxProfit[i+1], maxSoFar - current)
            maxProfit = max(maxProfit, leftToRightMaxProfit[i] + rightToLeftMaxProfit[i])
        
        return maxProfit

prices = [7,6,4,3,1]
ob = Solution()
print(ob.maxProfit(prices))
