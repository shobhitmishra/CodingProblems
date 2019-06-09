from typing import List
class TreeNode:
    def __init__(self, x):
        self.val = x
        self.left = None
        self.right = None

class Solution:
    def inorderTraversal(self, root: TreeNode) -> List[int]:
        result, stack = [], []        
        while True:
            if root:
                stack.append(root)
                root = root.left
            else:
                if len(stack) == 0:
                    break
                root = stack.pop()
                result.append(root.val)
                root = root.right    

        return result

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
print(ob.inorderTraversal(root))