from typing import List
class Solution:
    def stoneGame(self, piles: List[int]) -> bool:
        if not piles:
            return True
        pileLen = len(piles)
        dp = [[0 for _ in range(pileLen)] for _ in range(pileLen)]
        for i in range(pileLen -1, -1, -1):
            dp[i][i] = piles[i]
            for j in range(i+1,pileLen):
                if j - i == 1:
                    dp[i][j] = max(piles[i], piles[j])
                else:
                    iVal = piles[i] + min(dp[i+2][j], dp[i+1][j-1])
                    jVal = piles[j] + min(dp[i][j-2], dp[i+1][j-1])
                    dp[i][j] = max(iVal, jVal)
        totalSum = sum(piles)
        firstPlayerVal = dp[0][pileLen -1]
        return firstPlayerVal > totalSum - firstPlayerVal

ob = Solution()
l = []
print(ob.stoneGame(l))