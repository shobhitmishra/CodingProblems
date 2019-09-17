class TreeNode:
    def __init__(self, x):
        self.val = x
        self.left = None
        self.right = None

class Solution:
    inorderSuccessorValue = None    
    def inorderSuccessor(self, root: 'TreeNode', p: 'TreeNode') -> 'TreeNode':
        result = list()        
        self.inOrderTraversal(root, p, result)
        return self.inorderSuccessorValue
    
    def inOrderTraversal(self, root, target, stack):
        if root:
            self.inOrderTraversal(root.left, target, stack)
            if stack and stack[-1] == target:
                self.inorderSuccessorValue = root
            stack.append(root)                        
            self.inOrderTraversal(root.right, target, stack)            

root = TreeNode(10)
root.left = TreeNode(5)
root.left.left = TreeNode(3)
root.left.right = TreeNode(8)
root.left.right.left = TreeNode(7)
root.left.right.right = TreeNode(9)

root.right = TreeNode(15)
root.right.left = TreeNode(13)
root.right.right = TreeNode(18)
root.right.right.left = TreeNode(17)
root.right.right.left.left = TreeNode(16)

ob = Solution()
print(ob.inorderSuccessor(root, root.left).val)

