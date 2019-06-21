class TreeNode:
    def __init__(self, x):
        self.val = x
        self.left = None
        self.right = None

class Solution:    
    def pathSum(self, root: TreeNode, sum: int) -> int:
        if not root:
            return 0        
        return self.pathSumHelper(root, 0, sum) + self.pathSum(root.left, sum) + self.pathSum(root.right, sum)
        
    
    def pathSumHelper(self, root, currentSum, targetSum):
        if not root:
            return 0
        
        currentSum += root.val
        leftCount = self.pathSumHelper(root.left, currentSum, targetSum)
        rightCount = self.pathSumHelper(root.right, currentSum, targetSum)
        if currentSum == targetSum:                        
            return 1 + leftCount + rightCount
        return leftCount + rightCount
        

root = TreeNode(1)
root.right = TreeNode(2)
root.right.right = TreeNode(3)
root.right.right.right = TreeNode(4)
root.right.right.right.right = TreeNode(5)

ob = Solution()
print(ob.pathSum(root, 3))