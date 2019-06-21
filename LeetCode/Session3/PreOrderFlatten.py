class TreeNode:
    def __init__(self, x):
        self.val = x
        self.left = None
        self.right = None

class Solution:
    def flatten(self, root: TreeNode) -> None:
        if not root:
            return
        self.flattenHelper(root)
    
    def flattenHelper(self, root):
        if not root:
            return
        
        flattenedLeft = self.flattenHelper(root.left)
        flattenedRight = self.flattenHelper(root.right)
        if flattenedLeft:
            root.right = flattenedLeft
            root.left = None        
            lastOfLeft = self.getLastOfLinkList(flattenedLeft)
            lastOfLeft.right = flattenedRight
        return root
    
    def getLastOfLinkList(self, root):
        temp = root
        while temp.right:
            temp = temp.right
        return temp

root = TreeNode(1)
root.left = TreeNode(2)
root.left.left = TreeNode(3)
root.left.right = TreeNode(4)

root.right = TreeNode(5)
root.right.right = TreeNode(6)

ob = Solution()
ob.flatten(root)
print(root)