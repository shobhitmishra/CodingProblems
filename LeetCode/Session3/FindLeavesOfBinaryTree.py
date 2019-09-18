from typing import List
import collections

class TreeNode:
    def __init__(self, x):
        self.val = x
        self.left = None
        self.right = None

class Solution:
    def findLeaves(self, root: TreeNode) -> List[List[int]]:
        if not root:
            return []
        dictStore = collections.defaultdict(list)
        self.storeNodesInDepths(root, dictStore)
        result = []        
        for i in range(1,max(dictStore.keys()) +1):
            result.append(dictStore[i])
        return result
    
    def storeNodesInDepths(self, root, dictStore):
        if not root:
            return 0
        leftDepth = self.storeNodesInDepths(root.left, dictStore)
        rightDepth = self.storeNodesInDepths(root.right, dictStore)
        nodeDepth = 1 + max(leftDepth, rightDepth)
        dictStore[nodeDepth].append(root.val)
        return nodeDepth


root = TreeNode(1)
root.left = TreeNode(2)
root.left.left = TreeNode(4)
root.left.right = TreeNode(5)

root.right = TreeNode(3)
root.right.right = TreeNode(6)
root.right.right.left = TreeNode(7)
root.right.right.left.right = TreeNode(8)
root.right.right.left.right.left = TreeNode(9)

ob = Solution()
print(ob.findLeaves(None))
