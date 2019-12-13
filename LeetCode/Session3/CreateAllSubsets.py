from typing import List
class Solution:
    def subsets(self, nums: List[int]) -> List[List[int]]:
        results = []
        self.subsetsHelper(nums, 0, [], results)
        return results
    
    def subsetsHelper(self, nums: List[int], currentLevel, currentList, results):
        if currentLevel == len(nums):
            results.append(list(currentList))
        else:
            currentList.append(nums[currentLevel])
            self.subsetsHelper(nums, currentLevel + 1, currentList, results)
            currentList.pop()
            self.subsetsHelper(nums, currentLevel + 1, currentList, results)

ob = Solution()
l = []
print(ob.subsets(l))