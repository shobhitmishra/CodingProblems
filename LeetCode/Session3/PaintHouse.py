from typing import List
class Solution:
    def minCostII(self, costs: List[List[int]]) -> int:
        for i in range(1, len(costs)):
            prevHouseCosts = costs[i-1]
            minCost = min(prevHouseCosts)
            minCostIndex = prevHouseCosts.index(minCost)
            secondMinCost = min(prevHouseCosts[:minCostIndex] + prevHouseCosts[minCostIndex +1:])
            for j in range(len(prevHouseCosts)):
                costs[i][j] += secondMinCost if minCostIndex == j else minCost
        return min(costs[-1])

input = [[1,3,5,6,5], 
[5,2,3,8,6],
[2,6,4,9,4],
[6,4,6,12,3],
[3,5,7,15,1]]

ob = Solution()
print(ob.minCostII(input))