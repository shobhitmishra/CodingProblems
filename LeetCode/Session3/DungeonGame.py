from typing import List
import sys
class Solution:
    def calculateMinimumHP(self, dungeon: List[List[int]]) -> int:
        rows = len(dungeon)
        cols = len(dungeon[0])
        dp = [[sys.maxsize for _ in range(cols + 1)] for _ in range(rows + 1)]
        dp[rows][cols-1] = dp[rows-1][cols] = 1
        
        for i in range(rows-1, -1, -1):
            for j in range(cols-1, -1, -1):
                need = min(dp[i][j+1], dp[i+1][j]) - dungeon[i][j]
                dp[i][j] = 1 if need <= 0 else need

        return dp[0][0]

vals = [[-1, 1]]

ob = Solution()
print(ob.calculateMinimumHP(vals))
