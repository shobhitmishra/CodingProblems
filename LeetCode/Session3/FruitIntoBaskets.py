from typing import List
class Solution:
    def totalFruit(self, tree: List[int]) -> int:
        maxLength, start = 0, 0, 
        freqCounter = dict()
        for end, fruit in enumerate(tree):
            if fruit not in freqCounter:
                freqCounter[fruit] = 0
            freqCounter[fruit] += 1
            while len(freqCounter) > 2:
                fruittoRemove = tree[start]
                start += 1
                freqCounter[fruittoRemove] -= 1
                if freqCounter[fruittoRemove] == 0:
                    freqCounter.pop(fruittoRemove)
            maxLength = max(maxLength, end - start + 1)
        return maxLength

input = []
ob = Solution()
print(ob.totalFruit(input))