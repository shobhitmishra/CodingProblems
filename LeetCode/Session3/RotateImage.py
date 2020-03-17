from typing import List
class Solution:
    def rotate(self, matrix: List[List[int]]) -> None:
        # reverse columns
        size = len(matrix)
        for col in range(size):
            for row in range(size//2):
                matrix[row][col], matrix[~row][col] = matrix[~row][col], matrix[row][col]
        
        # swap across a diagonal
        for row in range(size):
            for col in range(row + 1, size):
                matrix[row][col], matrix[col][row] = matrix[col][row], matrix[row][col]
        return

ob = Solution()
input1 = [
  [1,2,3],
  [4,5,6],
  [7,8,9]
]
ob.rotate(input1)

input2 = [
  [ 5, 1, 9,11],
  [ 2, 4, 8,10],
  [13, 3, 6, 7],
  [15,14,12,16]
]
ob.rotate(input2)
input3 = [[1,2],[3,4]]
ob.rotate(input3)