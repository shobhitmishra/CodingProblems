from typing import List
class Solution:
    def maxProduct(self, nums: List[int]) -> int:
        minArr = [0] * len(nums)
        maxArr = [0] * len(nums)
        absMax = minArr[0] = maxArr[0] = nums[0]
        for i in range(1, len(nums)):
            num = nums[i]
            minMulHere = num * minArr[i-1]
            maxMulHere = num * maxArr[i-1]
            minArr[i] = min(num, minMulHere, maxMulHere)
            maxArr[i] = max(num, minMulHere, maxMulHere)
            absMax = max(absMax, minMulHere, maxMulHere, num)
        return absMax
        
ob = Solution()
arr = [1, 2, -3, 2, 3, -3]
print(ob.maxProduct(arr))