class Solution:
    def shortestCommonSupersequence(self, str1: str, str2: str) -> str:
        # this is an applied LC problem. 
        def getLcs(str1, str2):
            if not str1 or not str2:
                return ""
            dp = [["" for _ in range(len(str1) + 1)] for _ in range(len(str2) + 1)]
            for i in range(1, len(str2) +1):
                for j in range(1, len(str1) + 1):
                    if str2[i-1] == str1[j-1]:
                        dp[i][j] = dp[i-1][j-1] + str2[i-1]
                    else:
                        dp[i][j] = max(dp[i][j-1], dp[i-1][j], key=len)
            return dp[-1][-1]
        
        lcs = getLcs(str1, str2)
        result, i, j = "", 0 , 0
        for ch in lcs:
            while str1[i] != ch:
                result += str1[i]
                i +=1
            while str2[j] != ch:
                result += str2[j]
                j +=1
            result += ch
            i, j = i+1, j+1       
        return result + str1[i:] + str2[j:]

str1 = "abac"
str2 = "cab"
ob = Solution()
print(ob.shortestCommonSupersequence(str1, str2))