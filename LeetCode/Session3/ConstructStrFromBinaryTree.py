class TreeNode:
    def __init__(self, x):
        self.val = x
        self.left = None
        self.right = None

class Solution:
    def tree2str(self, t: TreeNode) -> str:
        if not t:
            return ""
    
        nodeStr = str(t.val)
        if not t.left and not t.right:
            return nodeStr
        
        nodeStr += "("
        if t.left:
            nodeStr += self.tree2str(t.left)
        nodeStr += ")"

        if t.right:
            nodeStr += "("
            nodeStr += self.tree2str(t.right)
            nodeStr += ")"
        return nodeStr

root = TreeNode(1)
root.left = TreeNode(2)
root.left.right = TreeNode(4)
root.right = TreeNode(3)

ob = Solution()
print(ob.tree2str(root))