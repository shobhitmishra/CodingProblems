class Solution:
    def longestPalindrome(self, s: str) -> str:
        if not s:
            return ""
        
        largestPalindrome = s[0]
        dp = [[False for j in range(len(s))] for i in range(len(s))]
        for i in range(len(s)):
            dp[i][i] = True
        for i in range(len(s) -2, -1, -1):
            for j in range(i + 1, len(s)):
                if s[i] == s[j] and (j-i == 1 or dp[i+1][j-1] == True):
                    dp[i][j] = True
                    if j - i + 1 > len(largestPalindrome):
                        largestPalindrome = s[i:j+1]

        return largestPalindrome
    
ob = Solution()
print(ob.longestPalindrome("babd"))
