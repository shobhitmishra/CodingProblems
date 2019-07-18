import sys
class TreeNode:
    def __init__(self, x):
        self.val = x
        self.left = None
        self.right = None

class Solution:
    minDiff = sys.maxsize
    prev = None
    def getMinimumDifference(self, root: TreeNode) -> int:
        self.getMinimumDifferenceHelper(root)
        return self.minDiff
    
    def getMinimumDifferenceHelper(self, root):
        if not root:
            return
        
        self.getMinimumDifferenceHelper(root.left)
        if self.prev:
            self.minDiff = min(self.minDiff, abs(root.val - self.prev.val))

        self.prev = root
        self.getMinimumDifferenceHelper(root.right)        

root = TreeNode(10)
root.left = TreeNode(3)
root.left.left = TreeNode(2)
root.left.right = TreeNode(8)
root.left.right.left = TreeNode(7)
root.left.right.right = TreeNode(9)

root.right = TreeNode(15)
root.right.left = TreeNode(13)
root.right.right = TreeNode(17)
root.right.right.right = TreeNode(19)
ob = Solution()
print(ob.getMinimumDifference(root))