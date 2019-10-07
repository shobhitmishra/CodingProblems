class Solution:
    def numRollsToTarget(self, d: int, f: int, target: int) -> int:
        if d == 0 or f == 0 or target == 0:
            return 0
        dp = [[0 for _ in range(target+1)] for _ in range(d+1)]
        for i in range(1,min(target,f)+1):
            dp[1][i] = 1
        
        for i in range(2,d+1):
            for j in range(i,target+1):
                for k in range(1,f+1):
                    if j - k > 0:
                        dp[i][j] += dp[i-1][j-k]
        return dp[d][target] % (10**9 + 7)

ob = Solution()
print(ob.numRollsToTarget(1,6,3))