from typing import List
from collections import deque
class Solution:
    def maxSlidingWindow(self, nums: List[int], k: int) -> List[int]:
        if not nums:
            return []
        def addToMonotonicDecreasingQueue(q: deque, item):
            while len(q) > 0 and q[-1] < item:
                q.pop()
            q.append(item)
        doubleEndedQueue = deque()
        for i in range(k):
            addToMonotonicDecreasingQueue(doubleEndedQueue, nums[i])        
        result = [doubleEndedQueue[0]]
        for i in range(k, len(nums)):
            numtopop = nums[i-k]
            if doubleEndedQueue[0] == numtopop:
                doubleEndedQueue.popleft()
            addToMonotonicDecreasingQueue(doubleEndedQueue, nums[i])
            result.append(doubleEndedQueue[0])        
        return result    


nums = [1,3,-1,-3,5,3,6,7]
k = 3
ob = Solution()
print(ob.maxSlidingWindow(nums,k))