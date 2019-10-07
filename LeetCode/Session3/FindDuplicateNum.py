from typing import List
class Solution:
    def findDuplicate(self, nums: List[int]) -> int:
        fast = nums[nums[0]]
        slow = nums[0]
        while fast!= slow:
            slow = nums[slow]
            fast = nums[nums[fast]]
        start = 0
        while slow != start:
            start = nums[start]
            slow = nums[slow]
        return start

input = [3,2,1,5,4,7,8,6,5]
ob = Solution()
print(ob.findDuplicate(input))
