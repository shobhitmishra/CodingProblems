from typing import List
class Solution:
    def kthSmallest(self, matrix: List[List[int]], k: int) -> int:
        size = len(matrix)
        low, high = matrix[0][0], matrix[size-1][size-1]
        while low < high:
            mid = (low + high)/2
            count, smaller, larger = self.countLessThanOrEqual(matrix, mid)
            if count == k:
                return smaller
            elif count < k:
                low = larger
            else:
                high = smaller
        return low
    
    def countLessThanOrEqual(self, matrix, target):
        size, count = len(matrix), 0
        i, j = size - 1, 0
        smaller, larger = matrix[0][0], matrix[size-1][size-1]
        while i >= 0 and j < size:
            num = matrix[i][j]
            if num > target:
                i -= 1
                larger = min(larger, num)
            else:
                count += i+1
                j +=1
                smaller = max(smaller, num)
        return count, smaller, larger

matrix = [[1,2],[1,3]]
ob = Solution()
#for i in range(1,9):
print(ob.kthSmallest(matrix,3))