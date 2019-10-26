from typing import List
from collections import defaultdict
import collections
class Solution:
    def numSubmatrixSumTarget(self, matrix: List[List[int]], target: int) -> int:
        # Calculate the prefix sum first
        num_rows, num_cols = len(matrix), len(matrix[0])
        for i in range(num_rows):
            for j in range(1, num_cols):
                matrix[i][j] += matrix[i][j-1]
        
        # now treat it is as the subarray sum problem, i and j are col numbers.
        # we are considering every pair of column numbers
        result = 0
        for i in range(num_cols):
            for j in range(i, num_cols):
                prefixSumCount = defaultdict(int)        
                prefixSumCount[0] = 1
                prefixsum = 0
                for row in range(num_rows):
                    prefixsum += matrix[row][j] - (matrix[row][i-1] if i > 0 else 0)
                    result += prefixSumCount[prefixsum - target]
                    prefixSumCount[prefixsum] += 1
        return result     
    
matrix = [
    [0,1,0],
    [1,1,1],
    [0,1,0]]
ob = Solution()
print(ob.numSubmatrixSumTarget([[0,1,1,1,1,0]], 1))