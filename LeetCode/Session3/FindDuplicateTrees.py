from typing import List
#from collections import defaultdict
class TreeNode:
    def __init__(self, x):
        self.val = x
        self.left = None
        self.right = None

class Solution:
    visited = dict()
    result = []
    def findDuplicateSubtrees(self, root: TreeNode) -> List[TreeNode]:
        self.preOrderTraversal(root)
        return self.result
    
    def preOrderTraversal(self, root):
        if not root:
            return "#"
        
        path = str(root.val) + self.preOrderTraversal(root.left) + self.preOrderTraversal(root.right)
        
        if path in self.visited and self.visited[path] == 1:
            self.result.append(root)
        
        if path not in self.visited:
            self.visited[path] = 0
        self.visited[path] +=1
        return path

ob = Solution()
root = TreeNode(1)
root.left = TreeNode(2)
root.left.left = TreeNode(4)

root.right = TreeNode(3)
root.right.right = TreeNode(4)
root.right.left = TreeNode(2)
root.right.left.left = TreeNode(4)

result = ob.findDuplicateSubtrees(root)
# root = TreeNode(2)
# root.left = TreeNode(1)
# root.right = TreeNode(1)
# result = ob.findDuplicateSubtrees(root)
print(result)
        