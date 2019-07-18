class TreeNode:
    def __init__(self, x):
        self.val = x
        self.left = None
        self.right = None

class Solution:
    tilt = 0
    def findTilt(self, root: TreeNode) -> int:
        self.findTiltHelper(root)
        return self.tilt
    
    def findTiltHelper(self, root):
        if not root:
            return 0
        
        leftSum = self.findTiltHelper(root.left)
        rightSum = self.findTiltHelper(root.right)
        self.tilt += abs(leftSum - rightSum)
        return leftSum + rightSum + root.val

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
print(ob.findTilt(root))
