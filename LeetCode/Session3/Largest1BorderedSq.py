from typing import List
class Solution:
    def largest1BorderedSquare(self, grid: List[List[int]]) -> int:
        rows = len(grid)
        cols = len(grid[0])
        upcount = [[0 for _ in range(cols)] for _ in range(rows)]
        leftCount = [[0 for _ in range(cols)] for _ in range(rows)]
        for i in range(rows):
            for j in range(cols):
                if grid[i][j]:
                    upcount[i][j] = 1 if i == 0 else 1 + upcount[i-1][j]
                    leftCount[i][j] = 1 if j == 0 else 1 + leftCount[i][j-1]
        
        max = 0
        for i in range(rows-1, -1, -1):
            for j in range(cols-1, -1, -1):
                target = min(upcount[i][j], leftCount[i][j])
                while target > max:
                    # check the left of up
                    leftOfUp = leftCount[i-target+1][j]
                    # check the up of left
                    upOfLeft = upcount[i][j-target+1]
                    if leftOfUp >= target and upOfLeft >= target:
                        max = target
                    target -= 1
        return max * max

ob = Solution()
grid = [[1,1,1],[1,0,1],[1,1,1]]
print(ob.largest1BorderedSquare(grid))
