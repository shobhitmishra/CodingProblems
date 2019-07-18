class TreeNode:
    def __init__(self, x):
        self.val = x
        self.left = None
        self.right = None

class Solution:
    first = second = prev = None
    def recoverTree(self, root: TreeNode) -> None:
        self.recoverTreeHelper(root)
        temp = self.first.val
        self.first.val = self.second.val
        self.second.val = temp
    
    def recoverTreeHelper(self, root):
        if not root:
            return
        
        self.recoverTreeHelper(root.left)
        if self.prev and self.prev.val > root.val:
            if not self.first:
                self.first = self.prev
                self.second = root
            else:
                self.second = root
        
        self.prev = root
        self.recoverTreeHelper(root.right)

ob  = Solution()
root = TreeNode(1)
root.left = TreeNode(3)
root.left.right = TreeNode(2)
#root.right.right = TreeNode(5)

ob.recoverTree(root)