from typing import List
class TreeNode:
    def __init__(self, x):
        self.val = x
        self.left = None
        self.right = None

class Solution:
    prev = None
    currCount = maxCount = 0
    def findMode(self, root: TreeNode) -> List[int]:
        result = []
        self.findModeHelper(root, result)
        return result

    def findModeHelper(self, root, result):
        if not root:
            return

        self.findModeHelper(root.left, result)
        if not self.prev or self.prev.val != root.val:
            self.prev = root
            self.currCount = 1
        elif self.prev.val == root.val:
            self.currCount += 1
        
        if self.currCount == self.maxCount:
            result.append(root.val)
        elif self.currCount > self.maxCount:
            self.maxCount = self.currCount
            result.clear()
            result.append(root.val)
        self.findModeHelper(root.right, result)

root = TreeNode(1)
root.right = TreeNode(2)
ob = Solution()
print(ob.findMode(root))




