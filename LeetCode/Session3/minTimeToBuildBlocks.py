from typing import List
import heapq
class Solution:
    def minBuildTime(self, blocks: List[int], split: int) -> int:
        if not blocks:
            return 0
        heapq.heapify(blocks)
        while len(blocks) > 1:
            item1 = heapq.heappop(blocks)
            item2 = heapq.heappop(blocks)
            heapq.heappush(blocks, max(item1, item2) + split)
        return blocks[0]

blocks = [1,2,3]
split = 3
ob = Solution()
print(ob.minBuildTime(blocks, split))