class TreeNode:
    def __init__(self, x):
        self.val = x
        self.left = None
        self.right = None

class Solution:
    newRoot = None
    def upsideDownBinaryTree(self, root: TreeNode) -> TreeNode:
        if not root:
            return None
        self.upsideDownBinaryTreeHelper(root)
        return self.newRoot
    
    def upsideDownBinaryTreeHelper(self, root):
        if not root.left:
            self.newRoot = root
            return root
        leftReverse = self.upsideDownBinaryTreeHelper(root.left)
        leftReverse.left = root.right
        leftReverse.right = root
        root.left = root.right = None
        return root

root = TreeNode(1)
root.right = TreeNode(3)
root.left = TreeNode(2)
root.left.right = TreeNode(5)
root.left.left = TreeNode(4)
root.left.left.right = TreeNode(7)
root.left.left.left = TreeNode(6)

ob = Solution()
newRoot = ob.upsideDownBinaryTree(root)
print(newRoot)