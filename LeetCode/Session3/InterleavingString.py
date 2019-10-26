class Solution:
    def isInterleave(self, s1: str, s2: str, s3: str) -> bool:
        if len(s3) != len(s1) + len(s2):
            return False
        dp = []
        for i in range(len(s2) + 1):
            dp.append([False] * (len(s1)+1))
        dp[0][0] = True

        # fill in the first row
        for j in range(1, len(s1) + 1):
            if s1[:j] == s3[:j]:
                dp[0][j] = True
        for i in range(1, len(s2) + 1):
            if s2[:i] == s3[:i]:
                dp[i][0] = True
        
        for i in range(1, len(s2) + 1):
            for j in range(1, len(s1) + 1):
                if s3[i+j-1] == s1[j-1] and dp[i][j-1] == True:
                    dp[i][j] = True
                if s3[i+j-1] == s2[i-1] and dp[i-1][j] == True:
                    dp[i][j] = True
        return dp[len(s2)][len(s1)]
    
s1 = "aabcc"
s2 = "dbbca"
s3 = "aadbbbaccc"
ob = Solution()
print(ob.isInterleave(s1, s2, s3))