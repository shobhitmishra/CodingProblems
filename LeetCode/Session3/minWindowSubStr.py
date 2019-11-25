from collections import Counter
class Solution:
    def minWindow(self, source: str, pattern: str) -> str:
        patternDict = Counter(pattern)
        matched, start = 0, 0
        minStart, minEnd = -1, len(source)
        for end, ch in enumerate(source):
            if ch in patternDict:
                patternDict[ch] -= 1
                if patternDict[ch] == 0:
                    matched += 1
            
            while matched == len(patternDict):
                if end - start + 1 < minEnd - minStart +1:
                    minStart, minEnd = start, end
                startChar = source[start]
                start += 1
                if startChar in patternDict:
                    if patternDict[startChar] == 0:
                        matched -= 1
                    patternDict[startChar] +=1
        return "" if minEnd-minStart+1 > len(source) else source[minStart: minEnd+1]

source = "AEGFDB"
pattern = "ABC"
ob = Solution()
print(ob.minWindow(source, pattern))
