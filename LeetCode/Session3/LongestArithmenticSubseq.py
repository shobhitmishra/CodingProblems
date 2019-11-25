from typing import List
from collections import defaultdict
class Solution:
    def longestSubsequence(self, arr: List[int], difference: int) -> int:
        maxLength = 0
        seqDict = defaultdict(int)
        for num in arr:
            seqDict[num] = max(seqDict[num], 1+ seqDict[num-difference])
            maxLength = max(maxLength, seqDict[num])
        return maxLength

l = [1,5,7,8,5,3,4,2,1]
ob = Solution()
print(ob.longestSubsequence(l,-2))