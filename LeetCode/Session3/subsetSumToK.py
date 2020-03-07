from typing import List
class Solution:
    def subarraySum(self, nums: List[int], k: int) -> int:
        dp = dict()
        def subarraySumRecursive(nums, index, k):
            key = (index, k)
            if key in dp:
                return dp[key]
            if k == 0:
                return 1
            if index >= len(nums):
                return 0
            count = subarraySumRecursive(nums, index + 1, k) + subarraySumRecursive(nums, index + 1, k - nums[index]) 
            dp[key] = count
            return count
        return subarraySumRecursive(nums, 0, k)       


nums = [1 for _ in range(3)]
#nums.extend([2 for _ in range(8)])
ob = Solution()
for i in range(10):
    print("num of sum for {0} is {1}".format(i, ob.subarraySum(nums, i)))