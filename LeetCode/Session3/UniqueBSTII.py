from typing import List
class TreeNode:
    def __init__(self, x):
        self.val = x
        self.left = None
        self.right = None

class Solution:
    def generateTrees(self, n: int) -> List[TreeNode]:
        if n <= 0:
            return []
        cache = dict()
        return self.generateTreesHelper(range(1,n+1), cache)
        
    def generateTreesHelper(self, nums, cache):
        if not nums:
            return [None]
        key = (nums[0], nums[-1])
        if key in cache:            
            return cache[key]
        result = []
        for i in range(len(nums)):
            left = self.generateTreesHelper(nums[:i], cache)
            right = self.generateTreesHelper(nums[i+1:], cache)

            for l in left:
                for r in right:
                    root = TreeNode(nums[i])
                    root.left = l
                    root.right = r
                    result.append(root)
        cache[key] = result
        return result

ob = Solution()
for i in range(7):
    result = ob.generateTrees(i)
    print(len(result))