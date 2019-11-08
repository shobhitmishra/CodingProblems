from collections import Counter
class Solution:
    def checkInclusion(self, pattern: str, source: str) -> bool:
        patternDict = Counter(pattern)
        sourceDict = dict()
        start = 0
        for end, ch in enumerate(source):
            if ch not in sourceDict:
                sourceDict[ch] = 0
            sourceDict[ch] +=1
            if end - start + 1 > len(pattern):
                sourceDict[source[start]] -= 1
                if sourceDict[source[start]] == 0:
                    del sourceDict[source[start]]
                start += 1

            if end - start + 1 == len(pattern):
                if patternDict == sourceDict:
                    return True
        return False

source = "eidcaboaoo"
pattern = "abc"
ob = Solution()
print(ob.checkInclusion(pattern, source))


