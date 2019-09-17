from typing import List
class Solution:
    def uniquePathsWithObstacles(self, obstacleGrid: List[List[int]]) -> int:
        if not obstacleGrid:
            return 0
        m = len(obstacleGrid)
        n = len(obstacleGrid[0])
        result = [[0 for _ in range(n)] for _ in range(m)]
        
        # populate top row
        for j in range(n):
            if obstacleGrid[0][j] == 1:
                break
            result[0][j] = 1
        
        # populate first column
        for i in range(m):
            if obstacleGrid[i][0] == 1:
                break
            result[i][0] = 1
        
        for i in range(1,m):
            for j in range(1,n):
                if obstacleGrid[i][j] == 1:
                    continue
                left = result[i][j-1]
                up = result[i-1][j]
                result[i][j] = left + up
        
        return result[m-1][n-1]

grid = [
  [0,0,0,0,0,0],
  [0,1,0,0,0,0],
  [0,0,0,1,0,1],
  [0,0,0,0,0,0],
  [0,0,0,0,0,0]
]
ob = Solution()
print(ob.uniquePathsWithObstacles(grid))
