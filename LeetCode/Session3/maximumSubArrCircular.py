from typing import List
class Solution:
    def maxSubarraySumCircular(self, A):
        total, maxSum, curMax, minSum, curMin = 0, -float('inf'), 0, float('inf'), 0
        for a in A:
            curMax = max(curMax + a, a)
            maxSum = max(maxSum, curMax)
            curMin = min(curMin + a, a)
            minSum = min(minSum, curMin)
            total += a
        return max(maxSum, total - minSum) if maxSum > 0 else maxSum

inputs = [[1,-2,3,-2], [5,-3,5], [3,-1,2,-1], [3,-2,2,-3], [-2,-3,-1]]
ob = Solution()
for i in inputs:
    print(ob.maxSubarraySumCircular(i))