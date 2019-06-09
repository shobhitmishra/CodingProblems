from typing import List
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
        self.pathSumHelper(root.left, requiredSum, pathSoFar, result)
        self.pathSumHelper(root.right, requiredSum, pathSoFar, result)
        pathSoFar.pop()

root = TreeNode(10)
root.left = TreeNode(8)
root.left.left = TreeNode(7)
root.left.right = TreeNode(9)

root.right = TreeNode(12)
root.right.left = TreeNode(5)
root.right.right = TreeNode(15)
root.right.right.right = TreeNode(17)
root.right.right.right.right = TreeNode(18)

root.right.right.left = TreeNode(13)
root.right.right.left.right = TreeNode(14)

ob = Solution()
print(ob.pathSum(root,27))
    