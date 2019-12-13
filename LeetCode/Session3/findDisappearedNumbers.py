from typing import List
class Solution:
    def findDisappearedNumbers(self, nums: List[int]) -> List[int]:
        i = 0
        while i < len(nums):
            reqIndex = nums[i] - 1
            if nums[reqIndex] != nums[i]:
                nums[i], nums[reqIndex] = nums[reqIndex], nums[i]
            else:
                i += 1
        
        result = []
        for index, num in enumerate(nums):
            if num != index + 1:
                result.append(index +1)
        return result


nums = [4,3,2,7,8,2,3,1]
ob = Solution()
print(ob.findDisappearedNumbers(nums))