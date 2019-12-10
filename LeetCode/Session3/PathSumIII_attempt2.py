from typing import List
class TreeNode:
    def __init__(self, x):
        self.val = x
        self.left = None
        self.right = None


class Solution:
    def pathSum(self, root: TreeNode, sum: int) -> int:
        def pathSumHelper(root: TreeNode, sum: int, pathSoFar: List):
            if not root:
                return 0
            pathSoFar.append(root.val)
            countSoFar, sumSoFar = 0, 0
            for i in range(len(pathSoFar) -1, -1, -1):
                sumSoFar += pathSoFar[i]
                if sumSoFar == sum:
                    countSoFar += 1
            
            countSoFar += pathSumHelper(root.left, sum, pathSoFar)
            countSoFar += pathSumHelper(root.right, sum, pathSoFar)
            pathSoFar.pop()
            return countSoFar

        return pathSumHelper(root, sum, [])

root = TreeNode(1)
root.left = TreeNode(7)
root.right = TreeNode(9)

root.left.left = TreeNode(6)
root.left.left.left = TreeNode(-2)
root.left.left.right = TreeNode(-1)
root.left.right = TreeNode(4)
root.left.right.right = TreeNode(-2)

root.right.left = TreeNode(2)
root.right.left.right = TreeNode(-1)
root.right.right = TreeNode(7)
root.right.right.right = TreeNode(-5)

ob = Solution()
print(ob.pathSum(root, 11))