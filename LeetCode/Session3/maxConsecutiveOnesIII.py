from typing import List
class Solution:
    def longestOnes(self, A: List[int], K: int) -> int:
        start, maxLength, oneCount = 0,0,0
        for end, num in enumerate(A):
            if num == 1:
                oneCount += 1            
            while end - start + 1 -oneCount > K:
                numAtStart = A[start]
                if numAtStart == 1:
                    oneCount -= 1                
                start += 1
            maxLength = max(maxLength, end-start+1)
        return maxLength

A = [0,0,1,1,0,0,1,1,1,0,1,1,0,0,0,1,1,1,1]
K = 3
ob = Solution()
print(ob.longestOnes(A,K))