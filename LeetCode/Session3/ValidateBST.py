import sys

class TreeNode:
    def __init__(self, x):
        self.val = x
        self.left = None
        self.right = None

class Solution:
    def isValidBST(self, root: TreeNode) -> bool:
        if not root:
            return True
        return self.isValidBSTHelper(root.left, -sys.maxsize, root.val) and self.isValidBSTHelper(root.right, root.val, sys.maxsize)

    def isValidBSTHelper(self, root: TreeNode, minVal: int, maxVal: int) -> bool:
        if not root:
            return True
        if root.val <= minVal or root.val >= maxVal:
            return False
        return self.isValidBSTHelper(root.left, minVal, root.val) and self.isValidBSTHelper(root.right, root.val, maxVal)
