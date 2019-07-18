from typing import List
class TreeNode:
    def __init__(self, x):
        self.val = x
        self.left = None
        self.right = None

class Solution:
    def buildTree(self, preorder: List[int], inorder: List[int]) -> TreeNode:
        if len(inorder) == 0:
            return None
        # get the first item from preOrder
        root = TreeNode(preorder[0])

        # search that node in inOrder traversal
        rootIndex = inorder.index(preorder[0])
        leftInOrder = inorder[:rootIndex]
        rightInOrder = inorder[1+rootIndex:]
        leftPreOrder = preorder[1: 1 + len(leftInOrder)]
        rightPreORder = preorder[-len(rightInOrder):]

        # build tree recursively
        root.left = self.buildTree(leftPreOrder, leftInOrder)
        root.right = self.buildTree(rightPreORder, rightInOrder)

        return root

preorder = [3,9,20,15,7]
inorder = [9,3,15,20,7]
ob = Solution()
root = ob.buildTree(preorder, inorder)
print(root)