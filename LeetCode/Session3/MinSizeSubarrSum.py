from typing import List
from sys import maxsize
class Solution:
    def minSubArrayLen(self, s: int, nums: List[int]) -> int:
        start, end, currSum = 0,0,0
        minLength = maxsize
        for end, value in enumerate(nums):
            currSum += value
            while currSum >= s:
                minLength = min(minLength, end-start +1)
                currSum -= nums[start]
                start +=1

        return 0 if minLength == maxsize else minLength

input = [2,3,1,2,4,3]
s = 7
ob = Solution()
print(ob.minSubArrayLen(s, input))