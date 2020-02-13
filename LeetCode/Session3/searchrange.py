from typing import List
class Solution:
    def searchRange(self, nums: List[int], target: int) -> List[int]:
        def getLastPosition(nums, target):
            if not nums:
                return -1
            start, end = 0 , len(nums) -1 
            while start <= end:
                mid = (start + end) // 2
                if target >= nums[mid]:
                    start = mid + 1
                else:
                    end = mid - 1
            return -1 if (start <= 0 or nums[start -1] != target) else start -1
            
        def getFirstPosition(nums, target):
            if not nums:
                return -1
            start, end = 0 , len(nums) -1 
            while start <= end:
                mid = (start + end) // 2
                if target <= nums[mid]:
                    end = mid - 1
                else:
                    start = mid + 1
            return -1 if (end >= len(nums) -1 or nums[end +1] != target) else end + 1

        lastPos = getLastPosition(nums, target)
        firstPos = getFirstPosition(nums, target)
        return [firstPos, lastPos]

nums = [2,2]
target = 1
ob = Solution()
print(ob.searchRange(nums, target))
    