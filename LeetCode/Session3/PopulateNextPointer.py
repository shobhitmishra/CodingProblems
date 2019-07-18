from collections import deque
class Node:
    def __init__(self, val, left, right, next):
        self.val = val
        self.left = left
        self.right = right
        self.next = next

class Solution:
    def connect(self, root: 'Node') -> 'Node':        
        if not root:
            return
        q = deque([root])
        while len(q) > 0:
            levelList = []
            for _ in range(len(q)):
                node = q.popleft()
                levelList.append(node.val)
                if node.left:
                    q.append(node.left)
                if node.right:
                    q.append(node.right)
            # populate next for every node
            for i in range(len(levelList) -1):
                levelList[i].next = levelList[i+1]
            if levelList:
                levelList[-1].next = None           
        return root
