# Definition for a binary tree node.
from collections import deque
from typing import List
class TreeNode:
    def __init__(self, x):
        self.val = x
        self.left = None
        self.right = None

class Solution:
    def zigzagLevelOrder(self, root: TreeNode) -> List[List[int]]:
        result = []
        level = 0        
        if not root:
            return result
        q = deque([root])
        while len(q) > 0:
            levelList = []
            level += 1
            for _ in range(len(q)):
                node = q.popleft()
                levelList.append(node.val)
                if node.left:
                    q.append(node.left)
                if node.right:
                    q.append(node.right)
            if level % 2 == 0:
                levelList.reverse()
            result.append(levelList)
        return result

ob = Solution()
root = TreeNode(3)
root.left = TreeNode(9)
root.right = TreeNode(20)
root.right.left = TreeNode(15)
root.right.right = TreeNode(7)
print(ob.zigzagLevelOrder(root))
