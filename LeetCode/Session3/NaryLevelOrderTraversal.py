from collections import deque
from typing import List
class Node:
    def __init__(self, val, children):
        self.val = val
        self.children = children

class Solution:
    def levelOrder(self, root: 'Node') -> List[List[int]]:
        result = []
        if not root:
            return result
        q = deque([root])
        while len(q) > 0:
            levelList = []
            for _ in range(len(q)):
                node = q.popleft()
                levelList.append(node.val)
                nodeChildren = node.children or []
                for child in nodeChildren:
                    if child:
                        q.append(child)
            result.append(levelList)
        return result
        