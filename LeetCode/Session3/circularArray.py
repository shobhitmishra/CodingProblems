from typing import List
class Solution:
    def circularArrayLoop(self, nums: List[int]) -> bool:
        def getNextIndex(index, nums, is_forward):
            direction = nums[index] > 0

            if is_forward != direction:
                return -1
            
            nextIndex = (index + nums[index]) % len(nums)            
            if nextIndex == index:
                return -1
            return nextIndex

        for index, num in enumerate(nums):
            if num == 0:
                continue
            
            is_forward = num > 0
            slow, fast = index, index

            while True:
                slow = getNextIndex(slow, nums, is_forward)
                fast = getNextIndex(fast, nums, is_forward)
                if fast != -1:
                    fast = getNextIndex(fast, nums, is_forward)
                if slow == -1 or fast == -1 or slow == fast:
                    break
            if slow != -1 and slow == fast:
                return True

        return False

nums = [[2,-1,1,2,2], [-1,2], [-2,1,-1,-2,-2]]
ob = Solution()
for num in nums:
    print(ob.circularArrayLoop(num))

