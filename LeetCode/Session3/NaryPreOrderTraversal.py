from typing import List
class Node:
    def __init__(self, val, children):
        self.val = val
        self.children = children

class Solution:
    def preorder(self, root: 'Node') -> List[int]:
        result = list()
        queue = list()
        if not root:
            return result
        
        queue.append(root)
        while len(queue) > 0:
            node = queue.pop()
            result.append(node.val)
            if node.children:
                queue.extend(node.children[::-1])
        return result

node5 = Node(5, None)
node6 = Node(6, None)
node3 = Node(3, [node5, node6])
node1 = Node(1, [node3, Node(2, None), Node(4, None)])

ob = Solution()
print(ob.preorder(node1))

