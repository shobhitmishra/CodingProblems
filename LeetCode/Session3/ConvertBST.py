class TreeNode:
    def __init__(self, x):
        self.val = x
        self.left = None
        self.right = None

class Solution:
    prevSum = 0
    def convertBST(self, root: TreeNode) -> TreeNode:
        self.convertBSTHelper(root)
        return root

    def convertBSTHelper(self, root):
        if not root:
            return
        self.convertBSTHelper(root.right)
        root.val += self.prevSum
        self.prevSum = root.val
        self.convertBSTHelper(root.left)
        

def InOrderTraversal(root, result):
    if root:
        InOrderTraversal(root.left, result)
        result.append(root.val)
        InOrderTraversal(root.right, result)

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
root = ob.convertBST(root)
result = []
InOrderTraversal(root, result)
print(result)

        