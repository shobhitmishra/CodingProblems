class Solution:
    def longestCommonSubsequence(self, text1: str, text2: str) -> int:
        if not text1 or not text2:
            return 0
        dp = [[0 for _ in range(len(text1) + 1)] for _ in range(len(text2) + 1)]
        for i in range(1, len(text2) + 1):
            for j in range(1, len(text1) + 1):
                dp[i][j] = max(dp[i][j-1], dp[i-1][j], 1 + dp[i-1][j-1] if text2[i-1] == text1[j-1] else 0)
        return dp[len(text2)][len(text1)]

text1 = "abc"
text2 = ""
ob = Solution()
print(ob.longestCommonSubsequence(text1, text2))
