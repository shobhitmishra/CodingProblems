from typing import List
class TreeNode:
    def __init__(self, x):
        self.val = x
        self.left = None
        self.right = None

class Solution:
    def postorderTraversal(self, root: TreeNode) -> List[int]:        
        result = []
        if not root:
            return result
        stack = [root]
        visited = set()
        while stack:
            curr = stack.pop()
            if curr in visited:
                result.append(curr.val)
            else:
                stack.append(curr)
                if curr.right:
                    stack.append(curr.right)
                if curr.left:
                    stack.append(curr.left)
                visited.add(curr)
        return result

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
print(ob.postorderTraversal(root)) 
