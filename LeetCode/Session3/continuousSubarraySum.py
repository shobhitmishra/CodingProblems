from typing import List
class Solution:
    def findMaxLength(self, nums: List[int]) -> int:
        if len(nums) < 2:
            return 0
        sumDict = {0: -1}
        currSum, maxLen = 0, 0
        for index, num in enumerate(nums):
            currSum += 1 if num == 1 else -1
            if currSum in sumDict:
                maxLen = max(maxLen, index - sumDict[currSum])
            else:
                sumDict[currSum] = index

        return maxLen

ob = Solution()
inputs = [[1,0,1,1,0,0], [1,1,1,0], [0,0,0,1], [1,1], [0,0], [1,0,0,0,0,0,1,1]]
for i in inputs:
    print(ob.findMaxLength(i))
        