from math import factorial
class Solution:
    def uniquePaths(self, m: int, n: int) -> int:
        return factorial(m+n-2)//(factorial(m-1) * factorial(n-1))

ob = Solution()
print(ob.uniquePaths(7,3))