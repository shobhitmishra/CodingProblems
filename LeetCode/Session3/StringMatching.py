from typing import List
class Solution:
    def stringMatching(self, words: List[str]) -> List[str]:
        result = []
        for word in words:
            for superWord in words:
                if word == superWord:
                    continue
                if word in superWord:
                    result.append(word)
                    break
        return result

words = ["leetcoder","leetcode","od","hamlet","am"]
ob = Solution()
print(ob.stringMatching(words))