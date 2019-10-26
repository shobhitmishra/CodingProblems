from typing import List
class Solution:
    def findMaxConsecutiveOnes(self, nums: List[int]) -> int:
        if not nums:
            return 0
        tempOneCount, maxOneCount = 0,0
        oneCount = []
        for i in range(len(nums)):
            num = nums[i]
            if num == 1:
                tempOneCount += 1
                if i+1 == len(nums) or nums[i+1] == 0:
                    oneCount.append(tempOneCount)
            else:                
                tempOneCount = 0
                oneCount.append(tempOneCount)
        for i in range(len(oneCount)):
            if oneCount[i] != 0:
                maxOneCount = max(maxOneCount, oneCount[i])
            else:
               leftOfThisBall = 0 if i == 0 else oneCount[i-1]
               rightOfThisBall = 0 if i == len(oneCount) - 1 else oneCount[i+1]
               maxOneCount = max(maxOneCount, 1 + leftOfThisBall + rightOfThisBall)
        return maxOneCount

ob = Solution()
input = [1,1,1,1,0,1]
print(ob.findMaxConsecutiveOnes(input))