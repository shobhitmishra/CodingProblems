from typing import List
from collections import deque
class Solution:
    def permuteUnique(self, nums: List[int]) -> List[List[int]]:
        ans = [[]]
        for num in nums:
            newAns = []
            for l in ans:
                for i in range(len(l) + 1):                    
                    newAns.append(l[:i] + [num] + l[i:])
                    if i < len(l) and num == l[i]:
                        break
            ans = newAns
        return ans

input = [1,2,2,2]
ob = Solution()
print(ob.permuteUnique(input))