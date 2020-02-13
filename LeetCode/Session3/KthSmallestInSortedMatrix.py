from typing import List
import heapq
class Solution:
    def kthSmallest(self, matrix: List[List[int]], k: int) -> int:
        heap = []
        for i in range(min(k, len(matrix))):
            heap.append((matrix[i][0], i, 0))
        heapq.heapify(heap)
        kthSmallestNum = 0
        while k > 0:
            kthSmallestNum, listIdx, itemIdx = heapq.heappop(heap)
            if itemIdx < len(matrix) - 1:
                itemIdx += 1
                heapq.heappush(heap, (matrix[listIdx][itemIdx], listIdx, itemIdx))
            k -=1
        return kthSmallestNum


matrix = [
   [ 1,  5,  9],
   [10, 11, 13],
   [12, 13, 15]
]
ob = Solution()
for i in range(1,9):
    print(ob.kthSmallest(matrix,i))