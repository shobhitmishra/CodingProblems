from typing import List
from sys import maxsize
class Solution:
    def threeSumClosest(self, nums: List[int], target: int) -> int:        
        bestSum = maxsize
        nums.sort()
        for i in range(len(nums)-2):
            if i > 0 and nums[i] == nums[i-1]:
                continue
            start, end = i + 1, len(nums) -1
            while start < end:
                tripletSum = nums[i] + nums[start] + nums[end]
                diff = abs(tripletSum - target)
                if diff < abs(bestSum - target):                    
                    bestSum = tripletSum
                if tripletSum < target:
                    while start < end and nums[start] == nums[start+1]:
                        start +=1
                    start += 1
                elif tripletSum > target:
                    while start < end and nums[end-1] == nums[end]:
                        end -=1
                    end -= 1
                else:
                    return bestSum
        return bestSum

nums = [1,1,1,0]
target = 100
ob = Solution()
print(ob.threeSumClosest(nums, target))