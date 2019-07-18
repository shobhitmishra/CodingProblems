class TreeNode:
    def __init__(self, x):
        self.val = x
        self.left = None
        self.right = None

class BSTIterator:
    stack = []    
    def __init__(self, root: TreeNode):        
        if root:
            curr = root
            while curr:
                self.stack.append(curr)
                curr = curr.left


    def next(self) -> int:
        """
        @return the next smallest number
        """
        top = self.stack.pop()
        if top.right:
            curr = top.right
            while curr:
                self.stack.append(curr)
                curr = curr.left
        return top.val
        

    def hasNext(self) -> bool:
        """
        @return whether we have a next smallest number
        """
        return len(self.stack) > 0

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

ob = BSTIterator(root)
while ob.hasNext():
    print(ob.next())
