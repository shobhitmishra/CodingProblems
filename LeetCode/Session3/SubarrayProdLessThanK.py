from typing import List
class Solution:
    def numSubarrayProductLessThanK(self, nums: List[int], target: int) -> int:
        if not nums:
            return 0
        start, count, prod = 0, 0, 1
        for end, num in enumerate(nums):
            if num >= target:
                prod = 1
                start = end + 1
                continue
            prod *= num
            while prod >= target:
                prod = prod / nums[start]
                start += 1
            # prod of all elements between start and end (inclusive) is less than target
            count += end - start + 1
        return count

nums = [10, 5, 4, 6]
target = 100
ob = Solution()
print(ob.numSubarrayProductLessThanK(nums, 3))
            
