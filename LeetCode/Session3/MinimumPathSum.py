from typing import List
class Solution:
    def minPathSum(self, grid: List[List[int]]) -> int:
        if not grid:
            return 0
        m = len(grid)
        n = len(grid[0])        
        
        # populate top row
        for j in range(1,n):            
            grid[0][j] += grid[0][j-1]
        
        # populate first column
        for i in range(1,m):            
            grid[i][0] += grid[i-1][0]
        
        for i in range(1,m):
            for j in range(1,n):
                grid[i][j] += min(grid[i][j-1], grid[i-1][j])
        
        return grid[m-1][n-1]

grid = [
  [1,3,1],
  [1,5,1],
  [4,2,1]
]

ob = Solution()
print(ob.minPathSum(grid))