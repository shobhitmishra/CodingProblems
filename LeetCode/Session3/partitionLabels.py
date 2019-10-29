from typing import List
from collections import defaultdict
class Solution:
    def partitionLabels(self, S: str) -> List[int]:
        if len(S) <= 1:
            return [len(S)]
        
        positionDict = defaultdict(list)
        for pos,char in enumerate(S):
            positionDict[char].append(pos)
        result = []
        startSegment, end = -1, -1
        for start in range(len(S)):            
            char = S[start]
            lastCharOccurence = positionDict[char][-1]
            end = max(end, lastCharOccurence)
            if start == end:
                result.append(end-startSegment)
                startSegment = end                
        return result

ob = Solution()
s = "ababcbacadefegdehijhklij"
print(ob.partitionLabels(s))