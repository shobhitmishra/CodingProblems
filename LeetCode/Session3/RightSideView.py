from collections import deque
from typing import List
class TreeNode:
    def __init__(self, x):
        self.val = x
        self.left = None
        self.right = None

class Solution:
    def rightSideView(self, root: TreeNode) -> List[int]:
        result = []
        if not root:
            return result
        queue = deque([root])
        while queue:
            # add the last element of queue
            result.append(queue[-1].val)
            for _ in range(len(queue)):
                curr = queue.popleft()
                if curr.left:
                    queue.append(curr.left)
                if curr.right:
                    queue.append(curr.right)
        return result

root = TreeNode(10)
root.left = TreeNode(5)
root.left.left = TreeNode(4)
root.left.left.right = TreeNode(8)
root.left.left.right.left = TreeNode(7)
root.left.left.right.left.right = TreeNode(9)

root.right = TreeNode(12)
root.right.left = TreeNode(3)
#root.right.left.right = TreeNode(6)

ob = Solution()
print(ob.rightSideView(root))
