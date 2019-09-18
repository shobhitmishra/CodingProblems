from typing import List
class TreeNode:
    def __init__(self, x):
        self.val = x
        self.left = None
        self.right = None

class Solution:
    def boundaryOfBinaryTree(self, root: TreeNode) -> List[int]:
        result = []
        if not root:
            return result
        result.append(root.val)
        self.leftBoundary(root.left, result)
        self.leaves(root.left, result)
        self.leaves(root.right, result)
        self.rightBoundary(root.right, result)
        return result
    
    def isNullOrLeaf(self, node):
        return not node or self.isLeaf(node)
    
    def isLeaf(self, node):
        if node and not node.left and not node.right:
            return True
        return False
    
    def leftBoundary(self, node, result):
        if self.isNullOrLeaf(node):
            return
        result.append(node.val)
        if node.left:
            self.leftBoundary(node.left, result)
        else:
            self.leftBoundary(node.right, result)
    
    def rightBoundary(self, node, result):
        if self.isNullOrLeaf(node):
            return        
        if node.right:
            self.rightBoundary(node.right, result)
        else:
            self.rightBoundary(node.left, result)
        result.append(node.val)
    
    def leaves(self, node, result):
        if node:
            if self.isLeaf(node):
                result.append(node.val)
                return
            self.leaves(node.left, result)
            self.leaves(node.right, result)

root = TreeNode(1)
root.right = TreeNode(2)
root.right.left = TreeNode(3)
root.right.right = TreeNode(4)

ob = Solution()
print(ob.boundaryOfBinaryTree(root))