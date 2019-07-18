from typing import List
class TreeNode:
    def __init__(self, x):
        self.val = x
        self.left = None
        self.right = None

class Solution:
    def printTree(self, root: TreeNode) -> List[List[str]]:
        if not root:
            return [[]]
    
        rows = self.getHeight(root)
        cols = 2 ** rows - 1 
        result = [["" for _ in range(cols)] for _ in range(rows)]
        self.populateResult(root, 0, 0, cols -1, result)
        return result

    def populateResult(self, node, currLevel, left, right, result):
        if not node:
            return
        mid = (left + right) // 2
        result[currLevel][mid] = str(node.val)
        self.populateResult(node.left, currLevel + 1, left, mid -1, result)
        self.populateResult(node.right, currLevel + 1, mid +1, right, result)

    def getHeight(self, root):
        if not root:
            return 0
        
        leftHeight = self.getHeight(root.left)
        rightHeight = self.getHeight(root.right)
        return 1 + max(leftHeight, rightHeight)

root = TreeNode(1)
root.left = TreeNode(2)
root.right = TreeNode(3)
root.left.left = TreeNode(4)
root.left.right = TreeNode(5)
ob = Solution()
print(ob.printTree(root))