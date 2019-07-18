from typing import List
class TreeNode:
    def __init__(self, x):
        self.val = x
        self.left = None
        self.right = None

class Solution:
    def binaryTreePaths(self, root: TreeNode) -> List[str]:
        result = []
        if not root:
            return result
        self.binaryTreePathsHelper(root, [], result)
        return result
    
    def binaryTreePathsHelper(self, root, pathSoFar, result):
        if root:
            pathSoFar.append(str(root.val))
            if not root.left and not root.right:
                path = "->".join(pathSoFar)
                result.append(path)
            self.binaryTreePathsHelper(root.left, pathSoFar, result)
            self.binaryTreePathsHelper(root.right, pathSoFar, result)
            pathSoFar.pop()

root = TreeNode(10)
root.left = TreeNode(3)
root.left.left = TreeNode(2)
root.left.right = TreeNode(8)
root.left.right.left = TreeNode(7)
root.left.right.right = TreeNode(9)

root.right = TreeNode(15)
root.right.left = TreeNode(13)
root.right.right = TreeNode(17)
root.right.right.right = TreeNode(19)

ob = Solution()
print(ob.binaryTreePaths(root))

            

