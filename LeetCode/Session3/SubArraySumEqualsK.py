from typing import List
from collections import defaultdict
class Solution:
    def subarraySum(self, nums: List[int], k: int) -> int:        
        prefixSumCount = defaultdict(int)
        result, preFixSum = 0, 0
        prefixSumCount[0] = 1
        for num in nums:
            preFixSum += num
            result += prefixSumCount[preFixSum - k]
            prefixSumCount[preFixSum] += 1
        return result

nums = [-1,1,0,-1,2,-2,1,3,-3,2,-1,1,-4,4]
ob = Solution()
print(ob.subarraySum(nums, 0))