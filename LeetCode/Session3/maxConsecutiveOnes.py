from typing import List
class Solution:
    def findMaxConsecutiveOnes(self, nums: List[int]) -> int:
        if not nums:
            return 0
        maxOneCount = 0
        tempOneCount = 0
        for num in nums:
            if num == 1:
                tempOneCount += 1
                maxOneCount = max(tempOneCount, maxOneCount)
            else:
                tempOneCount = 0
        return maxOneCount

ob = Solution()
nums = [1,1,0,1,1,1]
print(ob.findMaxConsecutiveOnes(nums))
