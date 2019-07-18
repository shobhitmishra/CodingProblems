class TreeNode:
    def __init__(self, x):
        self.val = x
        self.left = None
        self.right = None

class Solution:
    diameter = 0
    def diameterOfBinaryTree(self, root: TreeNode) -> int:
        self.diameterOfBinaryTreeHelper(root)
        return self.diameter

    def diameterOfBinaryTreeHelper(self, root):
        if not root:
            return 0
        
        maxNodesOnLeft = self.diameterOfBinaryTreeHelper(root.left)
        maxNodesOnRight = self.diameterOfBinaryTreeHelper(root.right)
        self.diameter = max(self.diameter, maxNodesOnLeft + maxNodesOnRight)
        return 1 + max(maxNodesOnLeft, maxNodesOnRight)

root = TreeNode(10)
root.left = TreeNode(3)
root.left.left = TreeNode(2)
root.left.right = TreeNode(8)
root.left.right.left = TreeNode(7)
root.left.right.right = TreeNode(9)

root.right = TreeNode(15)
root.right.left = TreeNode(13)
root.right.right = TreeNode(17)
root.right.right.right = TreeNode(19)
ob = Solution()
print(ob.diameterOfBinaryTree(root)) 

        
