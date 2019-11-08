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
                    while start + 1 < len(nums) and nums[start] == nums[start +1]:
                        start += 1                                        
                    while end > i and nums[end -1] == nums[end]:
                        end -=1
                    start +=1
                    end -=1
                elif sumOfNums < target:
                    start += 1
                else:
                    end -=1
        return result

input = [-1, 0, 1, 2, -1, -4]
#input = [-2, -2, -2, 0, 0, 0, 2, 2, 2, 2]
ob = Solution()
print(ob.threeSum(input))