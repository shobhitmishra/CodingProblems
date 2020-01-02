from typing import List
class Solution:
    def diffWaysToCompute(self, input: str) -> List[int]:
        if not str:
            return []
        cache = dict()
        return self.computeHelper(input, cache)        
    
    def computeHelper(self, input, cache):
        if input in cache:
            return cache[input]
        if not any(operator in input for operator in '*-+'):
            cache[input] = [int(input)]
        else:             
            result = []
            for index, ch in enumerate(input):
                if not ch.isnumeric():
                    left = self.computeHelper(input[:index], cache)
                    right = self.computeHelper(input[index+1:], cache)
                    for l in left:
                        for r in right:
                            if ch == '*':
                                result.append(l * r)
                            if ch == '+':
                                result.append(l + r)
                            if ch == '-':
                                result.append(l - r)
            cache[input] = result
        return cache[input]

s = "2*3-4*5"
ob = Solution()
print(ob.diffWaysToCompute(s))