from typing import List
class TreeNode:
    def __init__(self, x):
        self.val = x
        self.left = None
        self.right = None

class Solution:
    def buildTree(self, inorder: List[int], postorder: List[int]) -> TreeNode:
        if len(inorder) == 0:
            return None
        # get the last item from postorder
        root = TreeNode(postorder[-1])

        # search that node in inOrder traversal
        rootIndex = inorder.index(postorder[-1])
        leftInOrder = inorder[:rootIndex]
        rightInOrder = inorder[1+rootIndex:]
        leftPostOrder = postorder[0: len(leftInOrder)]
        rightPostORder = postorder[-(len(rightInOrder) + 1):-1]

        # build tree recursively
        root.left = self.buildTree(leftInOrder, leftPostOrder)
        root.right = self.buildTree(rightInOrder, rightPostORder)

        return root

inorder = [9,3,15,20,7]
postorder = [9,15,7,20,3]
ob = Solution()
root = ob.buildTree(inorder, postorder)
print(root)