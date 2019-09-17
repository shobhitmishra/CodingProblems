from typing import List
from collections import deque
class TreeNode:
    def __init__(self, x):
        self.val = x
        self.left = None
        self.right = None

class Solution:
    def closestKValues(self, root: TreeNode, target: float, k: int) -> List[int]:
        q = deque()
        self.closestKValuesHelper(root, target, k, q)
        return list(q)
    
    def closestKValuesHelper(self, node, target, k, q):
        if not node:
            return
        self.closestKValuesHelper(node.left, target, k, q)
        if len(q) < k:
            q.append(node.val)
        else:
            # append only if it is better
            if abs(target - q[0]) > abs(node.val - target):
                q.append(node.val)
                q.popleft()
            else:
                return

        self.closestKValuesHelper(node.right, target, k, q)

root = TreeNode(4)
root.left = TreeNode(2)
root.left.left = TreeNode(1)
root.left.right = TreeNode(3)
root.right = TreeNode(5)

ob = Solution()
print(ob.closestKValues(root, 3.714, 3))