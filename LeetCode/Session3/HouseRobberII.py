from typing import List
class Solution:
    def rob(self, nums: List[int]) -> int:
        if len(nums) == 1:
            return nums[0]
        return max(self.robHelper(nums[1:]), self.robHelper(nums[:-1]))

    def robHelper(self, nums):
        numLength = len(nums)
        endHere = [0] * (numLength + 1)
        notEndHere = [0] * (numLength + 1)
        for i in range(1, numLength + 1):
            endHere[i] = nums[i-1] + notEndHere[i-1]
            notEndHere[i] = max(endHere[i-1], notEndHere[i-1])
        return max(endHere[numLength], notEndHere[numLength])

ob = Solution()
nums = []
print(ob.rob(nums))