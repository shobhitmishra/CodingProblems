from typing import List
class TreeNode:
    def __init__(self, x):
        self.val = x
        self.left = None
        self.right = None

class Solution:
    def constructMaximumBinaryTree(self, nums: List[int]) -> TreeNode:
        if not nums:
            return None
        
        maxIdx = self.findMaxIndex(nums)
        node = TreeNode(nums[maxIdx])
        leftPart = nums[0:maxIdx]
        rightPart = nums[maxIdx + 1: len(nums)]
        node.left = self.constructMaximumBinaryTree(leftPart)
        node.right = self.constructMaximumBinaryTree(rightPart)
        return node
    
    def findMaxIndex(self, nums):
        maxIndex = 0
        for i in range(1,len(nums)):
            if nums[i] > nums[maxIndex]:
                maxIndex = i
        return maxIndex

nums = [3,2,1,6,0,5]
ob = Solution()
node = ob.constructMaximumBinaryTree(nums)
print(node)

