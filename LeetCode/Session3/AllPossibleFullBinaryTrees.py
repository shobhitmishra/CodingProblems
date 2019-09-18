from typing import List
class TreeNode:
    def __init__(self, x):
        self.val = x
        self.left = None
        self.right = None

class Solution:
    def allPossibleFBT(self, N: int) -> List[TreeNode]:
        if N <= 0 or N % 2 == 0:
            return []        
        
        if N == 1:
            return [TreeNode(0)]
        
        result = []
        for i in range(1, N, 2):
            for leftTree in self.allPossibleFBT(i):
                for rightTree in self.allPossibleFBT(N-i-1):
                    root = TreeNode(0)
                    root.left = leftTree
                    root.right = rightTree
                    result.append(root)
        
        return result

ob = Solution()
result = ob.allPossibleFBT(7)
print(result)
    