class TreeNode:
    def __init__(self, x):
        self.val = x
        self.left = None
        self.right = None

class Solution:
    def minDepth(self, root: TreeNode) -> int:
        if not root:
            return 0
        return self.minDepthHelper(root)
    def minDepthHelper(self, root: TreeNode) -> int:
        if not root.left and not root.right:
            return 1
        if not root.left:
            return 1 + self.minDepthHelper(root.right)
        if not root.right:
            return 1 + self.minDepthHelper(root.left)
        return 1 + min([self.minDepthHelper(root.left), self.minDepthHelper(root.right)])

ob = Solution()
root = TreeNode(1)
root.left = TreeNode(2)
# root.right = TreeNode(20)
# root.right.left = TreeNode(15)
# root.right.right = TreeNode(7)
print(ob.minDepth(root))