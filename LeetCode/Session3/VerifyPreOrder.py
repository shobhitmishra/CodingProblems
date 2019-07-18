from typing import List
import sys
class Solution:
    def verifyPreorder(self, preorder: List[int]) -> bool:
        if not preorder:
            return True
        return self.verifyPreorderHelper(preorder, 0, len(preorder) -1, -sys.maxsize-1, sys.maxsize)
    
    def verifyPreorderHelper(self, nums, start, end, minVal, maxVal):
        if start > end:
            return True
        
        root = nums[start]
        if start == end:
            return root >= minVal and root <= maxVal
        
        # find pivot Index
        pivotIndex = start + 1
        while pivotIndex <= end and nums[pivotIndex] < root:
            val = nums[pivotIndex]
            if val < minVal or val > maxVal:
                return False
            pivotIndex += 1
        
        # run it recursively
        return self.verifyPreorderHelper(nums, start+1, pivotIndex-1, minVal, root) and self.verifyPreorderHelper(nums, pivotIndex, end, root, maxVal)

ob = Solution()
nums = [4,2,3,1]
print(ob.verifyPreorder(nums))