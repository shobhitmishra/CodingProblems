from typing import List
class Solution:
    def generateAbbreviations(self, word: str) -> List[str]:
        start = ['']
        for ch in word:
            new_start = []
            for abb in start:
                # add as a char
                new_start.append(abb + ch)
                # add as numeric
                if not abb or abb[-1].isalpha():
                    new_start.append(abb + '1')
                else:
                    numeric = int(abb[-1]) + 1
                    new_start.append(abb[:-1] + str(numeric))
            start = new_start
        return start

input = 'code'
ob = Solution()
print(ob.generateAbbreviations(input))

