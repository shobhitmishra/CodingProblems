from typing import List
class Solution:
    def maxSubArray(self, nums: List[int]) -> int:
        currSum = nums[0]
        maxSum = nums[0]
        for i in range(1,len(nums)):            
            currSum = max(nums[i], currSum + nums[i])
            maxSum = max(maxSum, currSum)
        return maxSum
    
nums = [-2,1,-3,4,-1,2,1,-5,4]
ob = Solution()
print(ob.maxSubArray(nums))
