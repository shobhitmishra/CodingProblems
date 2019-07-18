class TreeNode:
    def __init__(self, x):
        self.val = x
        self.left = None
        self.right = None

class Solution:
    kthSmallestElement = 0
    counted = 0
    def kthSmallest(self, root: TreeNode, k: int) -> int:
        self.inOrderTraversal(root, k)
        return self.kthSmallestElement
    
    def inOrderTraversal(self, root, k):
        if root and k > self.counted:
            self.inOrderTraversal(root.left, k)
            self.counted += 1
            if k == self.counted:
                self.kthSmallestElement = root.val            
            self.inOrderTraversal(root.right, k)
    
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

for i in range(1,11):
    ob = Solution()
    print(ob.kthSmallest(root, i))