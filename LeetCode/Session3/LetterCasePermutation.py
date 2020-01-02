from typing import List
class Solution:
    def letterCasePermutation(self, S: str) -> List[str]:
        start = [[]]
        for ch in S:
            newStart = []
            for l in start:
                if ch.isnumeric():
                    newStart.append(l + [ch])
                else:
                    newStart.append(l + [ch.lower()])
                    newStart.append(l + [ch.upper()])
            start = newStart
        
        return ["".join(l) for l in start]

S = ""
ob = Solution()
print(ob.letterCasePermutation(S))
        