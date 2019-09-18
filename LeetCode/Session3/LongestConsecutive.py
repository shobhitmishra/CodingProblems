import sys
class TreeNode:
    def __init__(self, x):
        self.val = x
        self.left = None
        self.right = None

class Solution:
    maxLength = 0
    def longestConsecutive(self, root: TreeNode) -> int:
        self.longestConsecutiveHelper(root, 0, sys.maxsize)
        return self.maxLength
    
    def longestConsecutiveHelper(self, root, lengthSoFar, prevVal):
        if not root:
            return
        
        currLength = lengthSoFar + 1 if root.val == prevVal + 1 else 1
        self.maxLength = max(self.maxLength, currLength)
        self.longestConsecutiveHelper(root.left, currLength, root.val)
        self.longestConsecutiveHelper(root.right, currLength, root.val)

root = TreeNode(1)
root.right = TreeNode(3)
root.right.left = TreeNode(2)
root.right.right = TreeNode(4)
root.right.right.right = TreeNode(5)

ob = Solution()
print(ob.longestConsecutive(root))