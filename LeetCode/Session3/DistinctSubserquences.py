class Solution:
    def numDistinct(self, s: str, t: str) -> int:
        dp = []
        dp.append([1] * (len(s) + 1))
        for i in range(len(t)):
            dp.append([0] * (len(s) + 1))
        
        for i in range(1, len(t) + 1):
            for j in range(1, len(s) + 1):
                dp[i][j] = dp[i][j-1]
                if s[j-1] == t[i-1]:
                    dp[i][j] += dp[i-1][j-1]
        return dp[len(t)][len(s)]

ob = Solution()
s = "rabbbit"
t = "rabbit"
print(ob.numDistinct(t, s))