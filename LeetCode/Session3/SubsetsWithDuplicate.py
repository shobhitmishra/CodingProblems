from typing import List
class Solution:
    def subsetsWithDup(self, nums: List[int]) -> List[List[int]]:
        if not nums:
            return [[]]
        nums.sort()
        subsets = [[]]
        startIndex, endIndex = 0,0
        for i in range(len(nums)):
            startIndex = 0
            # Handle dups by setting the startIndex after the prev EndIndex
            if i > 0 and nums[i] == nums[i-1]:
                startIndex = endIndex + 1
            endIndex = len(subsets) - 1
            for j in range(startIndex, endIndex + 1):
                s = list(subsets[j])
                s.append(nums[i])
                subsets.append(s)
        return subsets

nums = [2,1,3,3,2]
ob = Solution()
print(ob.subsetsWithDup(nums))