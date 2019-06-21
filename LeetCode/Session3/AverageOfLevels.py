from typing import List
from collections import deque

class TreeNode:
    def __init__(self, x):
        self.val = x
        self.left = None
        self.right = None

class Solution:
    def averageOfLevels(self, root: TreeNode) -> List[float]:
        result = []
        if not root:
            return result
        
        q = deque()
        q.append(root)

        while q:
            length = len(q)
            sum = 0
            for _ in range(length):
                node = q.popleft()
                sum += node.val
                if node.left:
                    q.append(node.left)
                if node.right:
                    q.append(node.right)
            result.append(sum / length)
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
print(ob.averageOfLevels(root))