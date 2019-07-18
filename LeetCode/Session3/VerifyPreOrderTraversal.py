from typing import List
import sys
class Solution:
    def verifyPreorder(self, preorder: List[int]) -> bool:
        stack = list()
        root = -sys.maxsize -1
        for num in preorder:
            if num < root:
                return False
            
            while stack and stack[-1] < num:
                root = stack.pop()
            
            stack.append(num)
        return True

ob = Solution()
nums = [2,1]
print(ob.verifyPreorder(nums))