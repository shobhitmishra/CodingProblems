from typing import List
class Solution:
    def sortColors(self, nums: List[int]) -> None:
        curr, zeroPos, twoPos = 0, 0, len(nums) - 1
        while curr <= twoPos:
            if nums[curr] == 0:
                nums[zeroPos], nums[curr] = nums[curr], nums[zeroPos]
                curr += 1
                zeroPos += 1
            elif nums[curr] == 2:
                nums[twoPos], nums[curr] = nums[curr], nums[twoPos]
                twoPos -= 1
            else:
                curr += 1

inputList = [[0,0,1,2,1,2,1,1,1,2,2,2],
[0,0,0,0,0,0,2,2,2,2],
[2,2,2,2],
[1,1,1,1],
[0,0,0,0],
[2,0,2,1,1,0],
[2,0,1],
[]]

ob = Solution()
for input in inputList:
    ob.sortColors(input)
    print(input)