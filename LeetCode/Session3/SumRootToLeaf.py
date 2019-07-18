class TreeNode:
    def __init__(self, x):
        self.val = x
        self.left = None
        self.right = None

class Solution:
    finalSum = 0
    def sumNumbers(self, root: TreeNode) -> int:
        pathSoFar = []
        self.sumNumbersHelper(root, pathSoFar)
        return self.finalSum
    
    def sumNumbersHelper(self, root, pathSoFar):
        if not root:
            return
        pathSoFar.append(str(root.val))
        if not root.left and not root.right:
            num = int(''.join(pathSoFar))
            self.finalSum += num
        self.sumNumbersHelper(root.left, pathSoFar)
        self.sumNumbersHelper(root.right, pathSoFar)
        pathSoFar.pop()

root = TreeNode(4)
root.left = TreeNode(9)
root.left.left = TreeNode(5)
root.left.right = TreeNode(1)

root.right = TreeNode(0)
ob = Solution()
print(ob.sumNumbers(root))