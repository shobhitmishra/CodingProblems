from typing import List

# Definition for a binary tree node.
class TreeNode:
    def __init__(self, x):
        self.val = x
        self.left = None
        self.right = None

class Solution:
    def generateTrees(self, n: int) -> List[TreeNode]:
        if n < 1:
            return []
        cache = dict()
        return self.generateTreesRecursive(1,n,cache)        
    
    def generateTreesRecursive(self, start: int, end: int, cache) -> List[TreeNode]:
        if start > end:
            return [None]
        key = self.getKey(start, end)
        if key in cache:
            return cache[key]
        
        result = []
        for i in range(start, end+1):
            leftSubtrees = self.generateTreesRecursive(start, i-1, cache)
            rightSubtrees = self.generateTreesRecursive(i+1, end, cache)
            for left in leftSubtrees:
                for right in rightSubtrees:
                    tree = TreeNode(i)
                    tree.left = left
                    tree.right = right
                    result.append(tree)
            cache[key] = result
        return result
    
    def getKey(self, start: int, end: int) -> str:
        return str(start) + '-' + str(end)

ob = Solution()
ob.generateTrees(0)