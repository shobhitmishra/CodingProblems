from typing import List
class Solution:
    def maxProfit(self, k: int, prices: List[int]) -> int:   
        if not prices:
            return 0     
        if k >= len(prices) //2:
            return self.simpleSolve(prices)

        dp = [[0 for _ in range(len(prices))] for _ in range(k + 1)]

        for i in range(1,k+1):
            tempMax = -prices[0]
            for j in range(1,len(prices)):
                dp[i][j] = max(dp[i][j-1], prices[j] + tempMax)
                tempMax = max(tempMax, dp[i-1][j-1] - prices[j])
        return dp[k][len(prices)-1]
    
    def simpleSolve(self, prices):
        profit = 0
        for i in range(1,len(prices)):
            profit += max(prices[i]- prices[i-1], 0)

input = [3,2,6,5,0,3]
k = 2
ob = Solution()
print(ob.maxProfit(k, []))