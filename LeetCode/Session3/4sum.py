from typing import List
class Solution:
    def fourSum(self, nums: List[int], target: int) -> List[List[int]]:
        result = []
        nums.sort()
        for first in range(len(nums) -3):
            if first > 0 and nums[first] == nums[first -1]:
                continue
            for second in range(first + 1, len(nums) -2):
                if second > first + 1 and nums[second] == nums[second -1]:
                    continue
                start, end = second + 1, len(nums) -1
                while start < end:
                    elementsSum = nums[first] + nums[second] + nums[start] + nums[end]
                    if elementsSum == target:
                        result.append([nums[first], nums[second], nums[start], nums[end]])
                        while start < len(nums) -1 and nums[start] == nums[start +1]:
                            start += 1
                        while end > second and nums[end] == nums[end-1]:
                            end -= 1                        
                        start += 1
                        end -=1
                    elif elementsSum > target:
                        end -=1
                    else:
                        start +=1
        return result

nums = [1, 0, 1, 1, 1, 0, 0, -1, -1, -1, -1, 2, 2, 2, -2, -2, -2, 0, -1, 0, -2, 2]
target = 0
ob = Solution()
print(ob.fourSum(nums, target))