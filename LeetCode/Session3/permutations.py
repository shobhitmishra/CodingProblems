from typing import List
class Solution:
    def permute(self, nums: List[int]) -> List[List[int]]:
        results = []
        isIncluded = [False for _ in nums]
        self.permuteHelper(nums, [], isIncluded, results)
        return results
    
    def permuteHelper(self, nums, currentList: List[int], isIncluded, results):
        if len(currentList) == len(nums):
            results.append(list(currentList))
        else:
            for i in range(len(nums)):
                if isIncluded[i]:
                    continue
                # append the current item to the list
                currentList.append(nums[i])
                isIncluded[i] = True
                self.permuteHelper(nums, currentList, isIncluded, results)
                currentList.pop()
                isIncluded[i] = False

ob = Solution()
l = []
print(ob.permute(l))