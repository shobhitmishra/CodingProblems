from typing import List
class Solution:
    def subsetsWithDup(self, nums: List[int]) -> List[List[int]]:
        nums.sort()
        ans = [[]]
        for i in range(len(nums)):
            newAns = []
            subsetToIterate = prevSubset if i > 0 and nums[i] == nums[i-1] else ans
            for l in subsetToIterate:
                newAns.append(l +[nums[i]])
            prevSubset = newAns
            ans += newAns
        return ans

input = [1,2,2,2]
ob = Solution()
print(ob.subsetsWithDup(input))