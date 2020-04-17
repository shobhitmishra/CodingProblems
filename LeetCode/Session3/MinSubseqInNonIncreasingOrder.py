from typing import List
import math
# from builtins import sum
class Solution:
    def minSubsequence(self, nums: List[int]) -> List[int]:
        sortedList = sorted(nums, reverse=True)
        totalSum = sum(nums)
        requiredSum = math.ceil((totalSum+1)/2)
        result, tempSum  = [], 0
        for num in sortedList:
            tempSum += num
            result.append(num)
            if tempSum >= requiredSum:
                break
        return result

nums = [[4,3,10,9,8], [4,4,7,6,7], [3,2,10,5,6,9,7,8,3,4,7,2,1], [5]]
ob = Solution()
for l in nums:
    print(ob.minSubsequence(l))