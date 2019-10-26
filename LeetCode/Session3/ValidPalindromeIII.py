class Solution:
    def isValidPalindrome(self, s: str, k: int) -> bool:
        if not s:
            return True
        if s == s[::-1]:
            return True
        
        def longestPalindromeSubseq(s: str) -> int:            
            strLen = len(s)
            dp = [[0 for _ in range(strLen)] for _ in range(strLen)]

            for i in range(strLen-1, -1, -1):
                dp[i][i] = 1
                for j in range(i + 1, strLen):
                    dp[i][j] = max(dp[i][j-1], dp[i+1][j])
                    if s[i] == s[j]:                   
                            dp[i][j] = 2 + dp[i+1][j-1]        
            return dp[0][-1]

        longestPalSubSeq = longestPalindromeSubseq(s)
        return len(s) - longestPalSubSeq <= k

ob = Solution()
s = "abcdeca"
print(ob.isValidPalindrome(s, 2))