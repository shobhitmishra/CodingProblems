from typing import List
class Solution:
    def findUnsortedSubarray(self, nums: List[int]) -> int:
        if not nums:
            return 0
        monotonicIncreasing = list()
        for index in range(len(nums)):
            while len(monotonicIncreasing) > 0 and nums[monotonicIncreasing[-1]] > nums[index]:
                monotonicIncreasing.pop()
            monotonicIncreasing.append(index)
        
        if len(monotonicIncreasing) == len(nums):
            return 0
        
        startIndex = -1
        if monotonicIncreasing[0] == 0:
            for i in range(len(monotonicIncreasing)-1):
                if monotonicIncreasing[i+1] - monotonicIncreasing[i] != 1:
                    startIndex = monotonicIncreasing[i]
                    break
        
        monotonicDecreasing = list()
        for index in range(len(nums)-1, -1, -1):
            while len(monotonicDecreasing) > 0 and nums[monotonicDecreasing[-1]] < nums[index]:
                monotonicDecreasing.pop()
            monotonicDecreasing.append(index)
        
        endIndex = len(nums)
        if monotonicDecreasing[0] == len(nums) -1:
            for i in range(len(monotonicDecreasing) -1):
                if monotonicDecreasing[i] - monotonicDecreasing[i+1] != 1:
                    endIndex = monotonicDecreasing[i]
                    break
        
        return endIndex - startIndex -1

input = [3, 2, 1]
ob = Solution()
print(ob.findUnsortedSubarray(input))
