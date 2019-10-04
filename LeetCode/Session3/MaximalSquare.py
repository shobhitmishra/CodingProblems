from typing import List
class Solution:
    def maximalSquare(self, matrix: List[List[str]]) -> int:
        if not matrix:
                return 0
        rows = len(matrix)
        cols = len(matrix[0])
        dp = [[0 for _ in range(cols + 1)] for _ in range(rows + 1)]

        maxVal = 0
        for i in range(1, rows + 1):
            for j in range(1, cols + 1):
                if matrix[i-1][j-1] == "1":
                    dp[i][j] = min(dp[i][j-1], dp[i-1][j], dp[i-1][j-1]) + 1
                    maxVal = max(maxVal, dp[i][j])
        return maxVal * maxVal

matrix = [["1", "0", "1", "0", "0"],
["1", "0", "1", "1", "1"],
["1", "1", "1", "1", "1"],
["1", "1", "1", "1", "1"]]
ob = Solution()
print(ob.maximalSquare(matrix))