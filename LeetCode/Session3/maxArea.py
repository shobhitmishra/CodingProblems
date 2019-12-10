from typing import List
class Solution:
    def maxArea(self, height: List[int]) -> int:
        maxTrappedWater = 0
        start, end = 0, len(height) -1
        while start < end:
            # calculate the trapped water between start and end
            maxTrappedWater = max(maxTrappedWater, min(height[start], height[end]) * (end - start))
            if height[start] < height[end]:
                start += 1
            else:
                end -=1
        return maxTrappedWater


input = [1,8,6,2,5,4,8,3,7]
ob = Solution()
print(ob.maxArea(input))
