class TreeNode:
    def __init__(self, x):
        self.val = x
        self.left = None
        self.right = None

class Solution:
    def mergeTrees(self, t1: TreeNode, t2: TreeNode) -> TreeNode:
        if not t1 and not t2:
            return None
        
        val1 = 0 if not t1 else t1.val
        val2 = 0 if not t2 else t2.val
        node = TreeNode(val1 + val2)

        t1left = t2Left = t1Right = t2Right = None
        if t1:
            t1left = t1.left
            t1Right = t1.right
        if t2:
            t2Left = t2.left
            t2Right = t2.right
        node.left = self.mergeTrees(t1left, t2Left)
        node.right = self.mergeTrees(t1Right, t2Right)
        return node

t1 = TreeNode(1)
t1.left = TreeNode(3)
t1.left.left = TreeNode(5)
t1.right = TreeNode(2)

t2 = TreeNode(2)
t2.left = TreeNode(1)
t2.left.right = TreeNode(4)
t2.right = TreeNode(3)
t2.right.right = TreeNode(7)

ob = Solution()
node = ob.mergeTrees(t1, t2)
print(node)
