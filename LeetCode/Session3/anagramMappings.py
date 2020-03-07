from typing import List
class Solution:
    def anagramMappings(self, A: List[int], B: List[int]) -> List[int]:
        if not A:
            return []
        numIndexDict = dict()
        for index, num in enumerate(B):
            if num not in numIndexDict:
                numIndexDict[num] = list()
            numIndexDict[num].append(index)
        
        result = []
        for num in A:
            index = numIndexDict[num].pop()
            result.append(index)
        return result


A = [12, 28, 46, 32, 50, 12]
B = [50, 12, 32, 46, 12, 28]
ob = Solution()
print(ob.anagramMappings(A,B))
            