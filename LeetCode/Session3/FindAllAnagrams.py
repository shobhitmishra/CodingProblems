from typing import List
from collections import Counter
class Solution:
    def findAnagrams(self, source: str, pattern: str) -> List[int]:
        result = list()
        patternDict = Counter(pattern)        
        start, matched = 0,0
        for end, ch in enumerate(source):
            if ch in patternDict:
                patternDict[ch] -=1
                if patternDict[ch] == 0:
                    matched +=1
            
            if matched == len(patternDict):
                result.append(start)

            # narrow the window
            if end - start + 1 >= len(pattern):
                leftChar = source[start]
                start += 1
                if leftChar in patternDict:
                    if patternDict[leftChar] == 0:
                        matched -= 1
                    patternDict[leftChar] += 1
            
        return result

source = "baa"
pattern = "aa"
ob = Solution()
print(ob.findAnagrams(source, pattern))