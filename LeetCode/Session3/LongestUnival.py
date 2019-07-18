import sys
class TreeNode:
    def __init__(self, x):
        self.val = x
        self.left = None
        self.right = None
        
class Solution:
    longest = 0
    def longestUnivaluePath(self, root: TreeNode) -> int:
        self.longestUnivaluePathHelper(sys.maxsize, root)
        return self.longest
    
    def longestUnivaluePathHelper(self, parentVal, node):
        if not node:
            return 0
             
        leftNodes = self.longestUnivaluePathHelper(node.val, node.left)
        rightNodes = self.longestUnivaluePathHelper(node.val, node.right)
        self.longest = max(self.longest, leftNodes + rightNodes)
        if node.val == parentVal:
            return 1 + max(leftNodes, rightNodes)
        return 0

root = TreeNode(1)
root.left = TreeNode(4)
root.left.left = TreeNode(4)
root.left.right = TreeNode(4)

root.right = TreeNode(5)
root.right.right = TreeNode(5)

ob = Solution()
print(ob.longestUnivaluePath(root))
