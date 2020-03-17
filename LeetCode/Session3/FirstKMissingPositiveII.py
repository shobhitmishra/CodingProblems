from typing import List
class Solution:
    def firstMissingPositive(self, nums: List[int]) -> int:
        index = 0
        while index < len(nums):
            desiredIndex = nums[index] - 1
            if desiredIndex >= 0 and desiredIndex < len(nums) and nums[desiredIndex] != nums[index]:
                nums[desiredIndex], nums[index] = nums[index], nums[desiredIndex]
            else:
                index += 1
        for i in range(len(nums)):
            if i + 1 != nums[i]:
                return i + 1
        return len(nums) + 1

lists = [[1],[1,2,0], [3,4,-1,1], [7,8,9], [1,2,0,-1,3,4,1,2,3]]
ob = Solution()
for l in lists:
    print(ob.firstMissingPositive(l))