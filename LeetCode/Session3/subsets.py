from typing import List
class Solution:
    def subsets(self, nums: List[int]) -> List[List[int]]:
        ans = [[]]
        for num in nums:
            newAns = []
            for l in ans:
                newAns.append(l +[num])
            ans += newAns
        return ans

input = [1,2,3]
ob = Solution()
print(ob.subsets(input))

