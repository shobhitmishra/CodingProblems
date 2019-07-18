class TreeNode:
    def __init__(self, x):
        self.val = x
        self.left = None
        self.right = None
        
class Solution:
    def isSubtree(self, s: TreeNode, t: TreeNode) -> bool:
        if self.areTreesEqual(s,t):
            return True 
        if s.left and self.isSubtree(s.left, t):
            return True
        if s.right and self.isSubtree(s.right, t):
            return True
        return False
    
    def areTreesEqual(self, s, t):
        if not s and not t:
            return True
        if not s or not t:
            return False
        if s.val != t.val:
            return False
        return self.areTreesEqual(s.left, t.left) and self.areTreesEqual(s.right, t.right)
    
s = TreeNode(3)
s.left = TreeNode(4)
s.left.left = TreeNode(1)
s.left.right = TreeNode(2)
s.right = TreeNode(5)

t = TreeNode(4)
t.left = TreeNode(1)
t.right = TreeNode(2)

ob = Solution()
print(ob.isSubtree(s,t))
        
