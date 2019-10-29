from typing import List
from sys import maxsize
class Solution:
    def mctFromLeafValues(self, arr: List[int]) -> int:
        length = len(arr)
        if length <= 1:
            return 0
        dp = [[0 for _ in range(length)] for _ in range(length)]
        for i in range(length-2, -1, -1):
            for j in range(i+1, length):
                if j - i == 1:
                    dp[i][j] = arr[i] * arr[j]
                else:
                    tempVal = maxsize
                    for k in range(i, j):
                        val = dp[i][k] + dp[k+1][j] + max(arr[i:k+1]) * max(arr[k+1:j+1])
                        tempVal = min(tempVal, val)
                    dp[i][j] = tempVal
        return dp[0][-1]

l = [6,2,4,7,8,5,9]
ob = Solution()
print(ob.mctFromLeafValues(l))
                
