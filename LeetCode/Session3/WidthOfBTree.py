from collections import deque
class TreeNode:
    def __init__(self, x):
        self.val = x
        self.left = None
        self.right = None


class Solution:
    def widthOfBinaryTree(self, root: TreeNode) -> int:
        if not root:
            return 0
        
        q = deque()
        maxWidth = 1
        q.append((root, 1))
        while q:
            maxWidth = max(maxWidth, q[-1][1] - q[0][1] + 1)
            for _ in range(len(q)):
                node, index = q.popleft()
                if node.left:
                    q.append((node.left, 2*index -1))
                if node.right:
                    q.append((node.right, 2*index))
        return maxWidth

root = TreeNode(1)
root.left = TreeNode(3)
root.left.left = TreeNode(5)
root.right = TreeNode(2)
root.right.right = TreeNode(9)
ob = Solution()
print(ob.widthOfBinaryTree(root))
