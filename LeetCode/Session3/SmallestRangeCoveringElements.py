from typing import List
import heapq
class Solution:
    def smallestRange(self, nums: List[List[int]]) -> List[int]:
        # create a heap of the first elements of each List
        heap = []
        for listNum, list in enumerate(nums):
            heapq.heappush(heap, (list[0], 0, listNum))
        
        maxNumberSoFar = max([item[0] for item in heap])
        minRange, maxRange = heap[0][0], maxNumberSoFar
        while len(heap) == len(nums):
            # pop the element from heap and adjust 
            item, index, listNum = heapq.heappop(heap)

             # update the range          
            if maxNumberSoFar - item < maxRange - minRange:
                minRange, maxRange = item, maxNumberSoFar
        
            if index + 1 < len(nums[listNum]):
                index += 1
                item = nums[listNum][index]
                maxNumberSoFar = max(maxNumberSoFar, item)
                heapq.heappush(heap, (item, index, listNum))            
           
        return [minRange, maxRange]

nums = [[1, 9], [4, 12], [7, 10, 16]]
ob = Solution()
print(ob.smallestRange(nums))