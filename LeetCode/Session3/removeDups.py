from typing import List
class Solution:
    def removeDuplicates(self, nums: List[int]) -> int:
        if not nums:
            return 0
        i, posToCopy = 1,1
        for i in range(1,len(nums)):
            if nums[i] != nums[i-1]:
                nums[posToCopy] = nums[i]
                posToCopy += 1
        return posToCopy

input = [0,0,1,1,1,2,2,3,3,4]
ob = Solution()
print(ob.removeDuplicates(input))