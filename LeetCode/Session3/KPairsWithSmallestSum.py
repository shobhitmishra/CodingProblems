from typing import List
import heapq
class Solution:
    def kSmallestPairs(self, nums1: List[int], nums2: List[int], k: int) -> List[List[int]]:
        heap = []
        for n1 in nums1:
            for n2 in nums2:
                if len(heap) < k:
                    heapq.heappush(heap, (-n1-n2, [n1,n2]))
                else:
                    if heap and -heap[0][0] > n1 + n2:
                        heapq.heappop(heap)                        
                        heapq.heappush(heap, (-n1-n2, [n1,n2]))
                    else:
                        break
        return [heapq.heappop(heap)[1] for _ in range(k) if heap]

nums1 = [1, 7, 11]
nums2 = [2, 4, 6]
k = 3
ob = Solution()
print(ob.kSmallestPairs(nums1, nums2, k))