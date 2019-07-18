import sys
class TreeNode:
    def __init__(self, x):
        self.val = x
        self.left = None
        self.right = None


class Solution:
    totalUniVal = 0
    def countUnivalSubtrees(self, root: TreeNode) -> int:
        if not root:
            return 0
        self.uniValHelper(root, sys.maxsize)
        return self.totalUniVal
    
    def uniValHelper(self, node, prevVal):
        if not node:
            return True
        
        isLeftUniVal = self.uniValHelper(node.left, node.val)
        isRightUniVal = self.uniValHelper(node.right, node.val)
        if isLeftUniVal and isRightUniVal:
            self.totalUniVal +=1
        
        return node.val == prevVal and isLeftUniVal and isRightUniVal

root = TreeNode(5)
root.left = TreeNode(1)
root.left.left = TreeNode(5)
root.left.right = TreeNode(5)
root.right = TreeNode(5)
root.right.right = TreeNode(5)

ob = Solution()
print(ob.countUnivalSubtrees(root))
