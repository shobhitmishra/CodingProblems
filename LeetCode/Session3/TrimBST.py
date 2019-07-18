class TreeNode:
    def __init__(self, x):
        self.val = x
        self.left = None
        self.right = None
        
class Solution:
    def trimBST(self, root: TreeNode, L: int, R: int) -> TreeNode:
        if not root:
            return None
        
        if root.val < L:
            return self.trimBST(root.right, L, R)
        if root.val > R:
            return self.trimBST(root.left, L, R)
        root.left = self.trimBST(root.left, L, R)
        root.right = self.trimBST(root.right, L, R)
        return root

root = TreeNode(3)
root.right = TreeNode(4)
root.left = TreeNode(0)
root.left.right = TreeNode(2)
root.left.right.left = TreeNode(1)

ob = Solution()
node = ob.trimBST(root, 1, 3)
print(node)
            