from typing import List
class TreeNode:
    def __init__(self, x):
        self.val = x
        self.left = None
        self.right = None
        
class Solution:
    def findFrequentTreeSum(self, root: TreeNode) -> List[int]:
        counter = dict()
        self.findFrequentTreeSumHelper(root, counter)
        result = []
        maxCount = 0
        for key, val in counter.items():
            if val == maxCount:
                result.append(key)
            elif val > maxCount:
                result.clear()
                maxCount = val
                result.append(key)
        return result


    def findFrequentTreeSumHelper(self, root, counter):
        if not root:
            return 0
        
        nodeSum = root.val
        leftSum = self.findFrequentTreeSumHelper(root.left, counter)
        rightSum = self.findFrequentTreeSumHelper(root.right, counter)

        nodeSum += leftSum + rightSum
        if nodeSum not in counter:
            counter[nodeSum] = 0
        counter[nodeSum] += 1

        return nodeSum

root = TreeNode(5)
root.left = TreeNode(2)
root.right = TreeNode(-3)
ob = Solution()
print(ob.findFrequentTreeSum(root))