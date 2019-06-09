# Definition for a binary tree node.
class TreeNode:
    def __init__(self, x):
        self.val = x
        self.left = None
        self.right = None

class Solution:
    def isSymmetric(self, root: TreeNode) -> bool:
        if not root:
            return True
        return self.isSymmetricHelper(root.left, root.right)

    def isSymmetricHelper(self, leftNode: TreeNode, rightNode: TreeNode) -> bool:
        if not leftNode and not rightNode:
            return True
        if not leftNode or not rightNode:
            return False
        if leftNode.val != rightNode.val:
            return False
        return self.isSymmetricHelper(leftNode.left, rightNode.right) and self.isSymmetricHelper(leftNode.right, rightNode.left)