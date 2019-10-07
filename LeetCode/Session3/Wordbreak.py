from typing import List
class Solution:
    def wordBreak(self, s: str, wordDict: List[str]) -> bool:
        wordSet = set(wordDict)
        dp = [False] * (len(s) + 1)
        dp[0] = True
        for i in range(1, len(dp)):
            for j in range(i):
                if dp[j] == True and (s[j:i] in wordSet):
                    dp[i] = True
                    break
        return dp[-1]

s = "applepenapple"
wordDict = ["apple", "pen"]
ob = Solution()
print(ob.wordBreak(s, wordDict))