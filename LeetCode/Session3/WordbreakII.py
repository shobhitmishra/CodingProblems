from typing import List
class Solution:
    def wordBreak(self, s: str, wordDict: List[str]) -> List[str]:
        if not s:
            return []
        resultDict = dict()
        wordSet = set(wordDict)
        self.wordBreakHelper(s, wordSet, resultDict)
        return resultDict[s]
    
    def wordBreakHelper(self, s, wordset, resultDict):        
        if s in resultDict:
            return resultDict[s]
        
        stringResult = []
        for i in range(len(s) + 1):            
            word = s[:i]
            if word in wordset:
                if word == s:
                    stringResult.append(word)
                else:
                    restResult = self.wordBreakHelper(s[i:], wordset, resultDict)
                    if restResult:
                        res = [word + " " + item for item in restResult]
                        stringResult.extend(res)            
        resultDict[s] = stringResult
        return stringResult

s = "aaaaaaa"
wordDict = ["aaaa","aa","a"]
ob = Solution()
print(ob.wordBreak(s, wordDict))
