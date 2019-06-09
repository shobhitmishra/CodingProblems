from typing import List
class TreeNode:
    def __init__(self, x):
        self.val = x
        self.left = None
        self.right = None

class Solution:
    def hasPathSum(self, root: TreeNode, sum: int) -> bool:        
        return self.hasPathSumHelper(root, 0, sum)
    
    def hasPathSumHelper(self, root, sumSoFar, requiredSum):
        if not root:
            return False
        if not root.left and not root.right:
            return sumSoFar + root.val == requiredSum
        sum = root.val + sumSoFar
        return self.hasPathSumHelper(root.left, sum, requiredSum) or self.hasPathSumHelper(root.right, sum, requiredSum)
        

root = TreeNode(10)
root.left = TreeNode(8)
root.left.left = TreeNode(7)
root.left.right = TreeNode(9)

root.right = TreeNode(12)
root.right.left = TreeNode(11)
root.right.right = TreeNode(15)
root.right.right.right = TreeNode(17)
root.right.right.right.right = TreeNode(18)

root.right.right.left = TreeNode(13)
root.right.right.left.right = TreeNode(14)

root2 = TreeNode(1)
root2.right = TreeNode(2)

ob = Solution()
print(ob.hasPathSum(root, 25))