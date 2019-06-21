from collections import deque
class TreeNode:
    def __init__(self, x):
        self.val = x
        self.left = None
        self.right = None

class Solution:
    def addOneRow(self, root: TreeNode, v: int, d: int) -> TreeNode:
        if d == 1:
            node = TreeNode(v)
            node.left = root
            return node
        
        nodes = self.getNodesAtDepth(d-1, root)
        for node in nodes:
            leftNode = TreeNode(v)
            rightNode = TreeNode(v)            
            leftNode.left = node.left
            rightNode.right = node.right
            node.left = leftNode
            node.right = rightNode
        return root

    def getNodesAtDepth(self, depth, root):
        q = deque()
        q.append(root)
        currDepth = 1
        while q:
            if currDepth == depth:
                return q
            for _ in range(len(q)):
                node = q.popleft()
                if node.left:
                    q.append(node.left)
                if node.right:
                    q.append(node.right)
            currDepth +=1            

t2 = TreeNode(2)
t2.left = TreeNode(1)
t2.left.right = TreeNode(4)
t2.right = TreeNode(3)
t2.right.right = TreeNode(7)
ob = Solution()
node = ob.addOneRow(t2, 17, 3)
print(node)