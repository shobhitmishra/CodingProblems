class Solution:
    def isMatch(self, s: str, p: str) -> bool:
        dp = [[False for _ in range(len(s) + 1)] for _ in range(len(p) + 1)]
        dp[0][0] = True
        for i in range(1,len(p)+1):
            if p[i-1] == '*':
                dp[i][0] = dp[i-2][0]

        for i in range(1, len(p) + 1):
            for j in range(1, len(s) + 1):
                pChar = p[i-1]
                schar = s[j-1]
                pPrev = p[i-2] if i > 1 else ''
                if self.isCharMAtch(pChar, schar):
                    dp[i][j] = dp[i-1][j-1]
                elif pChar == '*': 
                    if self.isCharMAtch(pPrev, schar):
                        # using 1 of prev or multiple of prev
                        dp[i][j] = dp[i-1][j] or dp[i][j-1]                    
                    # using 0 of prev
                    if dp[i-2][j]:
                        dp[i][j] = True
        return dp[len(p)][len(s)]
    
    def isCharMAtch(self, pChar, sChar):
        return pChar == '.' or pChar == sChar
        
ob = Solution()
source = "aasdfasdfasdfasdfas"
pattern = "aasdf.*asdf.*asdf.*asdf.*s"
print(ob.isMatch(source, pattern))