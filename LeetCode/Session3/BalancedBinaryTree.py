class TreeNode:
    def __init__(self, x):
        self.val = x
        self.left = None
        self.right = None

class Solution:
    def isBalanced(self, root: TreeNode) -> bool:
        if not root:
            return True
        balanced, _ = self.isBalancedHelper(root)
        return balanced
    
    def isBalancedHelper(self, root: TreeNode):
        if not root:
            return [True, 0]
        isLeftBalanced, leftHt = self.isBalancedHelper(root.left)
        isRightBalanced, rightHt = self.isBalancedHelper(root.right)

        height = 1 + max([leftHt, rightHt])
        isBalanced = isLeftBalanced & isRightBalanced & (abs(leftHt - rightHt) <= 1)
        return [isBalanced, height]

root = TreeNode(10)
root.left = TreeNode(8)
root.left.left = TreeNode(7)
root.left.right = TreeNode(9)

root.right = TreeNode(12)
root.right.left = TreeNode(11)
root.right.right = TreeNode(15)
root.right.right.right = TreeNode(17)
root.right.right.right.right = TreeNode(18)

root.right.right.left = TreeNode(13)
root.right.right.left.right = TreeNode(14)

ob = Solution()
print(ob.isBalanced(root.right.right))