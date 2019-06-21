class TreeNode:
    def __init__(self, x):
        self.val = x
        self.left = None
        self.right = None

class Solution:
    def rob(self, root: TreeNode) -> int:
        return max(self.robHelper(root))
    
    def robHelper(self, root):
        if not root:
            return 0,0
        
        leftWith, leftWithout = self.robHelper(root.left)
        rightWith, rightWithout = self.robHelper(root.right)

        currentWithout = max(leftWith, leftWithout) + max(rightWith, rightWithout)
        currentWith = root.val + leftWithout + rightWithout
        return currentWith, currentWithout
    
root = TreeNode(3)
root.left = TreeNode(2)
root.right = TreeNode(3)

#root.left.left = TreeNode(1)
root.left.right = TreeNode(3)

root.right.right = TreeNode(1)

ob = Solution()
print(ob.rob(root))