from typing import List
class Solution:
    def minCost(self, costs: List[List[int]]) -> int:
        if not costs:
            return 0        
        numOfHouses = len(costs)        
        dp = [[0,0,0] for _ in range(numOfHouses + 1)]

        for i in range(1,numOfHouses + 1):
            dp[i][0] = costs[i-1][0] + min(dp[i-1][1], dp[i-1][2])
            dp[i][1] = costs[i-1][1] + min(dp[i-1][0], dp[i-1][2])
            dp[i][2] = costs[i-1][2] + min(dp[i-1][0], dp[i-1][1])
        return min(dp[-1])

ob = Solution()
costs = [[17,2,17]]
print(ob.minCost(costs))
