from sys import maxsize
class TreeNode:
    def __init__(self, x):
        self.val = x
        self.left = None
        self.right = None

class Solution:
    maxSum = -maxsize
    def maxPathSum(self, root: TreeNode) -> int:
        self.maxSumHelper(root)
        return self.maxSum
    
    def maxSumHelper(self, root):
        if not root:
            return -maxsize
        leftmax = self.maxSumHelper(root.left) + root.val
        rightmax = self.maxSumHelper(root.right) + root.val
        maxAtThisNode = max([root.val, leftmax, rightmax, leftmax + rightmax - root.val])
        self.maxSum = max([self.maxSum, maxAtThisNode])
        return max([leftmax, rightmax, root.val])

root = TreeNode(-10)
root.left = TreeNode(7)
root.left.left = TreeNode(-9)
root.left.right = TreeNode(8)
root.left.right.left = TreeNode(-6)
root.left.right.right = TreeNode(-12)

root.right = TreeNode(-5)
root.right.right = TreeNode(10)
root.right.right.left = TreeNode(1)
root.right.right.right = TreeNode(6)

ob = Solution()
print(ob.maxPathSum(root))