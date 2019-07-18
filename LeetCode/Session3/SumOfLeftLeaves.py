class TreeNode:
    def __init__(self, x):
        self.val = x
        self.left = None
        self.right = None

class Solution:
    sumLeaves = 0
    def sumOfLeftLeaves(self, root: TreeNode) -> int:
        if root:
            # check if left child is leaf
            if root.left and not root.left.left and not root.left.right:
                self.sumLeaves += root.left.val
            self.sumOfLeftLeaves(root.left)
            self.sumOfLeftLeaves(root.right)
        return self.sumLeaves

root = TreeNode(10)
root.left = TreeNode(3)
root.left.left = TreeNode(2)
root.left.right = TreeNode(8)
#root.left.right.left = TreeNode(7)
root.left.right.right = TreeNode(9)

root.right = TreeNode(15)
root.right.left = TreeNode(13)
root.right.right = TreeNode(17)
root.right.right.right = TreeNode(19)
ob = Solution()
print(ob.sumOfLeftLeaves(root))
    