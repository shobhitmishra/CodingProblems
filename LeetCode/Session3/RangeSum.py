class TreeNode:
    def __init__(self, x):
        self.val = x
        self.left = None
        self.right = None

class Solution:
    totalSum = 0
    def rangeSumBST(self, root: TreeNode, L: int, R: int) -> int:
        self.preOrderTraversal(root, L, R)
        return self.totalSum
    
    def preOrderTraversal(self, root, L, R):
        if root:
            if root.val >= L and root.val <= R:
                self.totalSum += root.val
            self.preOrderTraversal(root.left, L, R)
            self.preOrderTraversal(root.right, L, R)
