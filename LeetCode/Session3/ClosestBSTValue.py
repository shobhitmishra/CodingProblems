import sys
class TreeNode:
    def __init__(self, x):
        self.val = x
        self.left = None
        self.right = None
class Solution:    
    def closestValue(self, root: TreeNode, target: float) -> int:
        self.minDiffValue = root.val
        self.closestValueHelper(root, target)
        return self.minDiffValue
    
    def closestValueHelper(self, node: TreeNode, target: float):
        if not node:
            return
        currentDiff = abs(node.val - target)
        if currentDiff < abs(self.minDiffValue - target):
            self.minDiffValue = node.val
        
        if target < node.val:
            self.closestValueHelper(node.left, target)
        else:
            self.closestValueHelper(node.right, target)

ob = Solution()
root = TreeNode(4)
root.left = TreeNode(2)
root.left.left = TreeNode(1)
root.left.right = TreeNode(3)
root.right = TreeNode(5)

print(ob.closestValue(root, 3.14))