import sys
class TreeNode:
    def __init__(self, x):
        self.val = x
        self.left = None
        self.right = None

class Solution:
    largestBstSize = 1
    def largestBSTSubtree(self, root: TreeNode) -> int:
        if not root:
            return 0

        self.largestBstHelper(root)
        return self.largestBstSize
    
    def largestBstHelper(self, root):
        if not root:
            return (True, sys.maxsize, -sys.maxsize, 0)

        isLeftBst, leftSmallest, leftLargest, leftSize = self.largestBstHelper(root.left,)
        isRightBst, rightSmallest, rightLargest, rightSize = self.largestBstHelper(root.right,)
        currentSize = leftSize + rightSize + 1
        isBst = isLeftBst and isRightBst and root.val > leftLargest and root.val < rightSmallest
        if(isBst):
            self.largestBstSize = max(self.largestBstSize, currentSize)
        return (isBst, min(root.val, leftSmallest, rightSmallest), max(root.val, leftLargest, rightLargest), currentSize)

root = TreeNode(10)
root.left = TreeNode(5)
root.left.left = TreeNode(1)
root.left.right = TreeNode(8)
root.left.right.right = TreeNode(9)

root.right = TreeNode(15)
root.right.right = TreeNode(17)
# root1 = TreeNode(1)
# root1.left = TreeNode(2)

ob = Solution()
print(ob.largestBSTSubtree(root))