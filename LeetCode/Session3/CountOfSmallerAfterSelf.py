from typing import List
class Solution:
    def countSmaller(self, nums: List[int]) -> List[int]:
        if not nums:
            return []
        result = [0] * len(nums)
        stack = [nums[-1]]
        for i in range(len(nums)-2 , -1, -1):
            num = nums[i]
            while stack and stack[-1] > num:
                stack.pop()
            result[i] = len(stack)
            stack.append(num)
        return result

ob = Solution()
inputs = [[5,2,6,1], [1,2,3,4], [4,3,2,1], [-8,-1,2,-9,0]]
for l in inputs:
    print(ob.countSmaller(l))