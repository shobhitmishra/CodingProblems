from typing import List
class Solution:
    def canJump(self, nums: List[int]) -> bool:
        farthestPossibleJump = 0
        for i, val in enumerate(nums):
            if i > farthestPossibleJump:
                return False
            farthestPossibleJump = max(farthestPossibleJump, i + val)            
            if farthestPossibleJump >= len(nums) -1:
                return True

input = [2,3,1,1,4]
ob = Solution()
print(ob.canJump(input))