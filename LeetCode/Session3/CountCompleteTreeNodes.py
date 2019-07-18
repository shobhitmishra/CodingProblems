class TreeNode:
    def __init__(self, x):
        self.val = x
        self.left = None
        self.right = None

class Solution:
    def countNodes(self, root: TreeNode) -> int:
        if not root:
            return 0
        leftHeight = self.getLeftHeight(root)
        rightHeight = self.getRightHeight(root)
        if leftHeight == rightHeight:
            return 2**leftHeight - 1
        
        return 1 + self.countNodes(root.left) + self.countNodes(root.right)

    def getLeftHeight(self, root):
        height = 0
        while root:
            root = root.left
            height +=1
        return height
    
    def getRightHeight(self, root):
        height = 0
        while root:
            root = root.right
            height +=1
        return height

root = TreeNode(1)
root.left = TreeNode(2)
root.left.left = TreeNode(4)
root.left.right = TreeNode(5)

root.right = TreeNode(3)
root.right.left = TreeNode(6)
root.right.right = TreeNode(7)
ob = Solution()
print(ob.countNodes(root))