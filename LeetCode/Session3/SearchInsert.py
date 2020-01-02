from typing import List
class Solution:
    def searchInsert(self, nums: List[int], target: int) -> int:
        start, end = 0, len(nums) - 1
        while start <= end:
            mid = (start + end) // 2
            if target == nums[mid]:
                return mid
            if target > nums[mid]:
                start = mid + 1
            else:
                end = mid - 1
        return start

input = [1,3,5,6]
targets = [5,2,7,0]
ob = Solution()
for target in targets:
    print(ob.searchInsert(input, target))