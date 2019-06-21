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
        flattenedLeft = root
        if root.left:        
            flattenedLeft = self.flattenHelper(root.left)        
            lastOfLeft = self.getLastOfLinkList(flattenedLeft)
            lastOfLeft.right = root
        root.left = None
        root.right = self.flattenHelper(root.right)          
        
        return flattenedLeft        
    
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
temp = ob.flattenHelper(root)
print(temp)