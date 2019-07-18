class Node:
    def __init__(self, val, children):
        self.val = val
        self.children = children

class Solution:
    def maxDepth(self, root: 'Node') -> int:
        if not root:
            return 0
        maxChildDepth = max([self.maxDepth(child) for child in root.children]) if root.children else 0
        return 1+maxChildDepth

node5 = Node(5, None)
node6 = Node(6, None)
node3 = Node(3, [node5, node6])
node1 = Node(1, [Node(2, None), Node(4, None), node3])

ob = Solution()
print(ob.maxDepth(node3))