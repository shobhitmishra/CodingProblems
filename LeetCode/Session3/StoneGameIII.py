from typing import List
class Solution:
    def stoneGameIII(self, stoneValue: List[int]) -> str:
        n = len(stoneValue)
        suffixSum = [0] * (n + 1)
        dp = [0] * (n + 1)
        for i in range(n-1, -1, -1):
            suffixSum[i] = stoneValue[i] + suffixSum[i+1]
        for i in range(n-1, -1, -1):
            dp[i] = stoneValue[i] + suffixSum[i+1] - dp[i+1]
            for k in range(3):
                if i + k >= n:
                    break
                dp[i] = max(dp[i], (suffixSum[i] - suffixSum[i+k+1]) + (suffixSum[i+k+1] - dp[i+k+1]))
        
        # dp[0] represents the max possible points for Alice starts with first stone
        if 2*dp[0] == suffixSum[0]:
            #both Alice and Bob got the same points
            return "Tie"
        elif 2*dp[0] > suffixSum[0]:
            return "Alice"
        else:
            return "Bob"

inputs = [[1,2,3,7], [1,2,3,-9], [1,2,3,6], [1,2,3,-1,-2,-3,7], [-1,-2,-3]]
#inputs = [[-1, -2, -3]]
ob = Solution()
for input in inputs:
    print(ob.stoneGameIII(input))
