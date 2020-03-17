from typing import List
class Solution:
    def search(self, nums: List[int], target: int) -> int:
        start, end = 0, len(nums) - 1
        while start <= end:
            mid = (start + end)//2
            if target == nums[mid]:
                return mid
            # if left is sorted
            if nums[start] <= nums[mid]:
                # if target is in left
                if target >= nums[start] and target < nums[mid]:
                    end = mid - 1
                else:
                    start = mid + 1
            else:
                # if target is in right
                if target > nums[mid] and target <= nums[end]:
                    start = mid + 1
                else:
                    end = mid - 1
        return -1

nums = [4,5,6,7,8,0,1,2]
ob = Solution()
for i in range(9):
    print(ob.search(nums, i))
print(ob.search([3,1],3))
print(ob.search([3,1],1))