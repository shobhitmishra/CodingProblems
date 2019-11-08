from typing import List
from collections import Counter
from collections import defaultdict
class Solution:
    def findSubstring(self, source: str, words: List[str]) -> List[int]:
        if not words:
            return []
        wordCount, wordLen = len(words), len(words[0])
        windowSize = wordCount * wordLen
        if len(source) < windowSize:
            return []
        result = []
        wordDict = Counter(words)
        for i in range(len(source) - windowSize + 1):
            wordSeen = defaultdict(int)
            for j in range(wordCount):
                wordStart = i + j * wordLen
                wordToken = source[wordStart: wordStart + wordLen]
                if wordToken not in wordDict:
                    break      
                wordSeen[wordToken] +=1
                if wordSeen[wordToken] > wordDict[wordToken]:
                    break
                if j + 1 == wordCount:
                    result.append(i)
        return result

source = "wordgoodgoodwordgoodbestword"          
words = ["word","good","best","word"]
ob = Solution()
print(ob.findSubstring(source, words))
