from typing import List
class Solution:
    def processQueries(self, queries: List[int], m: int) -> List[int]:
        permutation = list(range(1, m+1))
        result = []
        for i in queries:
            index = permutation.index(i)
            result.append(index)
            permutation = [i] + permutation[:index] + permutation[index+1:]
        return result

queries = [7,5,5,8,3]
m = 8
ob = Solution()
print(ob.processQueries(queries, m))