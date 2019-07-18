class TreeNode:
    def __init__(self, x):
        self.val = x
        self.left = None
        self.right = None

class Solution:
    found = False
    def findTarget(self, root: TreeNode, k: int) -> bool:
        visited = set()
        self.InOrderTraversal(root, k, visited)
        return self.found
    
    def InOrderTraversal(self, node, target, visited):
        if node and not self.found:
            self.InOrderTraversal(node.left, target, visited)
            if (target - node.val) in visited:
                self.found = True                
                return
            visited.add(node.val)
            self.InOrderTraversal(node.right, target, visited)

root = TreeNode(10)
root.left = TreeNode(10)
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
print(ob.findTarget(root, 67))