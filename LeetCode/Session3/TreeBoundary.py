from typing import List
from collections import deque
# Definition for a binary tree node.
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
        if self.isLeaf(root):
            return [root.val]
        result.append(root.val)
        self.leftBoundary(root.left, result)
        result += self.dfs_leaves(root)
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
    
    def dfs_leaves(self, root):
            if not root:
                return []
            stack, result = [root], []
            while stack:
                node = stack.pop()
                if not node.left and not node.right:
                    result.append(node.val)
                if node.right:
                    stack.append(node.right)
                if node.left:
                    stack.append(node.left)
            return result

root = TreeNode(12)
root.left = TreeNode(7)
root.right = TreeNode(1)
root.left.left = TreeNode(4)
root.left.left.left = TreeNode(9)
root.left.right = TreeNode(3)
root.left.right.left = TreeNode(15)
root.right.left = TreeNode(10)
root.right.right = TreeNode(5)
root.right.right.left = TreeNode(6)
ob = Solution()
print(ob.boundaryOfBinaryTree(root))

        