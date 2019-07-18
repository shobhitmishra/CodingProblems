import sys
class TreeNode:
    def __init__(self, x):
        self.val = x
        self.left = None
        self.right = None
class Solution:    
    def findSecondMinimumValue(self, root: TreeNode) -> int:
        if not root or (not root.left and not root.right):
            return -1
        
        if root.left.val < root.right.val:
            secondMinInLeft = self.findSecondMinimumValue(root.left)
            return root.right.val if secondMinInLeft == -1 else min(root.right.val, secondMinInLeft)
        elif root.left.val > root.right.val:
            secondMinInRight = self.findSecondMinimumValue(root.right)
            return root.left.val if secondMinInRight == -1 else min(root.left.val, secondMinInRight)
        else:
            secondMinInLeft = self.findSecondMinimumValue(root.left)
            secondMinInRight = self.findSecondMinimumValue(root.right)
            if secondMinInLeft == -1 and secondMinInRight == -1:
                return -1
            elif secondMinInLeft == -1:
                return secondMinInRight
            elif secondMinInRight == -1:
                return secondMinInLeft            
            return min(secondMinInLeft, secondMinInRight)
            
            
    

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
print(ob.findSecondMinimumValue(root))