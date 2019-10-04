
from typing import List
class Solution:
    def rob(self, nums: List[int]) -> int:
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
        