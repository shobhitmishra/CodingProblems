from typing import List
class Solution:
    def missingNumber(self, nums: List[int]) -> int:
        i = 0
        while i < len(nums):
            reqIndex = nums[i]
            if reqIndex < len(nums) and nums[reqIndex] != nums[i]:
                nums[i], nums[reqIndex] = nums[reqIndex], nums[i]
            else:
                i += 1
        
        for index, num in enumerate(nums):
            if num != index:
                return index
        return len(nums)

input = [8,6,4,2,3,5,7,0,1]
ob = Solution()
print(ob.missingNumber(input))