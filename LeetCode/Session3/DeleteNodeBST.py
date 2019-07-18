class TreeNode:
    def __init__(self, x):
        self.val = x
        self.left = None
        self.right = None

class Solution:
    node = parent = None
    def deleteNode(self, root: TreeNode, key: int) -> TreeNode:
        # search for the node and its parent
        self.findNodeAndParent(root, key)
        if self.node == root and not root.left and not root.right:
            return None
        if self.node:           
            self.deleteNodeHelper(self.node, self.parent)
        
        return root
    
    def deleteNodeHelper(self, node, parent):
        # if node is a leaf
        if not node.left and not node.right:
            if parent:
                if parent.left == node:
                    parent.left = None
                else:
                    parent.right = None
            return
        
        # if node has only one child
        if not node.left or not node.right:
            child = node.left if not node.right else node.right
            node.val = child.val
            node.left = child.left
            node.right = child.right
            return
        
        # node has two children
        successor, succesorParent = self.getNodeSuccessor(node)
        node.val = successor.val
        self.deleteNodeHelper(successor, succesorParent)
        

    def getNodeSuccessor(self, node):
        succesorParent = node
        successor = node.right
        while successor.left:
            succesorParent = successor
            successor = successor.left
        return successor, succesorParent



    def findNodeAndParent(self, root, key):
        if not root:
            return
        if root.val == key:
            self.node = root
            return
        self.parent = root
        if key < root.val:
            self.findNodeAndParent(root.left, key)
        else:
            self.findNodeAndParent(root.right, key)

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
root = TreeNode(50)
root = ob.deleteNode(root, 50)
print(root)
