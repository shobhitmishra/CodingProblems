from typing import List
class Solution:
    def sortedSquares(self, A: List[int]) -> List[int]:
        start, end = 0, len(A) -1
        result = []
        while start <= end:
            endNum = A[end] * A[end]
            startNum = A[start] * A[start]
            if endNum > startNum:
                result.append(endNum)
                end -= 1
            else:
                result.append(startNum)
                start +=1 
        return result[::-1]

input = []
ob = Solution()
print(ob.sortedSquares(input))