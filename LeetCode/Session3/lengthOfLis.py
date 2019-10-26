from typing import List
class Solution:
    def lengthOfLIS(self, nums: List[int]) -> int:
        if not nums:
            return 0
        maxLen = 1
        dp = [1] * len(nums)
        for i in range(len(nums)):
            for j in range(i):
                if nums[i] > nums[j]:
                    dp[i] = max(dp[i], 1 + dp[j])
            maxLen = max(maxLen, dp[i])
        return maxLen

ob = Solution()
nums = [10,9,2,5,3,7,101,18]
print(ob.lengthOfLIS(nums))