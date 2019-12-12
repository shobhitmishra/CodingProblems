from typing import List
from collections import deque
class Solution:
    def permute(self, nums: List[int]) -> List[List[int]]:
        ans = [[]]
        for num in nums:
            newAns = []
            for l in ans:
                for i in range(len(l) + 1):                    
                    newAns.append(l[:i] + [num] + l[i:])
            ans = newAns
        return ans


input = [1,2,3]
ob = Solution()
print(ob.permute(input))

        