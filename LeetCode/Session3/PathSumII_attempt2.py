from typing import List
# Definition for a binary tree node.
class TreeNode:
    def __init__(self, x):
        self.val = x
        self.left = None
        self.right = None

class Solution:
    def pathSum(self, root: TreeNode, requiredSum: int) -> List[List[int]]:
        result = []
        if not root:
            return result
        self.pathSumHelper(root, requiredSum, [], result)
        return result
    
    def pathSumHelper(self, root, requiredSum, pathSoFar, result):
        if not root:
            return
        pathSoFar.append(root.val)
        #if node is leaf
        if not root.left and not root.right:
            if sum(pathSoFar) == requiredSum:
                copyOfPath = [e for e in pathSoFar]
                result.append(copyOfPath)
                return
        self.pathSumHelper(root.left, requiredSum, pathSoFar, result)
        self.pathSumHelper(root.right, requiredSum, pathSoFar, result)
        pathSoFar.pop()