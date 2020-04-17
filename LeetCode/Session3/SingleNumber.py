from typing import List
import functools
class Solution:
    def singleNumber(self, nums: List[int]) -> int:
        xorResult = functools.reduce(lambda a,b: a^b, nums)
        return xorResult

nums = [7,6,1,2,1,2,3,4,4,3,5,6,5]
ob  = Solution()
print(ob.singleNumber(nums))