from typing import List
class Solution:
    def maximalRectangle(self, matrix: List[List[str]]) -> int:
        if not matrix:
            return 0
        maxRectangleSize = 0
        rowLength = len(matrix[0])
        heights = [0] * rowLength
        for i in range(len(matrix)):
            for j in range(rowLength):
                heights[j] = heights[j] + 1 if matrix[i][j] == "1" else 0
            maxRectangleSize = max(maxRectangleSize, self.largestRectangleArea(heights))

        return maxRectangleSize

    def largestRectangleArea(self, heights: List[int]) -> int:
        left = [-1 for _ in heights]
        right = [len(heights) for _ in heights]
        stack = []
        for i in range(len(heights)):
            num = heights[i]
            while stack and heights[stack[-1]] >= num:
                stack.pop()            
            if stack:
                left[i] = stack[-1]
            stack.append(i)

        stack.clear()

        for i in range(len(heights)-1, -1, -1):
            num = heights[i]
            while stack and heights[stack[-1]] >= num:
                stack.pop()            
            if stack:
                right[i] = stack[-1]
            stack.append(i)
        
        maxrectangle = 0
        for i in range(len(heights)):
            area = (right[i] - left[i] - 1) * heights[i]
            maxrectangle = max(maxrectangle, area)
        return maxrectangle

input = [
  ["1","0","1","0","0"],
  ["1","0","1","1","1"],
  ["1","1","1","1","1"],
  ["1","0","0","1","0"]
]
ob = Solution()
print(ob.maximalRectangle(input))
