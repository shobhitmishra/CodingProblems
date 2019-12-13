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
        q = deque()
        q.append(root)
        while q:
            prevNode = None
            for _ in range(len(q)):
                currNode = q.popleft()
                if prevNode:
                    prevNode.next = currNode
                if currNode.left:
                    q.append(currNode.left)
                if currNode.right:
                    q.append(currNode.right)
                prevNode = currNode
        return root