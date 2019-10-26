from typing import List
class Solution:
    def findTargetSumWays(self, nums: List[int], target: int) -> int:
        totalSum = sum(nums)
        if target > totalSum:
            return 0
        if (totalSum + target) % 2 != 0:
            return 0
        return self.findTargetSumWaysHelper(nums, (totalSum + target)//2)
    
    def findTargetSumWaysHelper(self, nums, target):        
        dp = [0] * (target + 1)
        dp[0] = 1
        for num in nums:
            for i in range(target, num -1, -1):
                dp[i] += dp[i - num]
        return dp[target]

ob = Solution()
nums = [2,20,24,38,44,21,45,48,30,48,14,9,21,10,46,46,12,48,12,38]
target = 48
print(ob.findTargetSumWays(nums, target))