from typing import List
class Solution:
    def threeSum(self, nums: List[int]) -> List[List[int]]:
        nums.sort()
        result = []
        for i in range(len(nums) -2):            
            if nums[i] > 0:
                break
            if i > 0 and nums[i] == nums[i-1]:
                continue
            target = -nums[i]
            start, end = i+1, len(nums) -1
            while start < end:
                sumOfNums = nums[start] + nums[end]
                if sumOfNums == target:
                    result.append([nums[i], nums[start], nums[end]])
                    start +=1                   
                    end -=1                   
                elif sumOfNums < target:
                    start += 1
                else:
                    end -=1
        return result

nums = [-2,0,0,2,2]
ob = Solution()
print(ob.threeSum(nums))
            