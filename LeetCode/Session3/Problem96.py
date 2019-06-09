class Solution:
    def numTrees(self, n: int) -> int:
        result = [1,1]
        for i in range(2, n+1):
            result.append(0)
            for j in range(i):
                result[i] += result[j] * result[i-1-j]
        #print(result)
        return result[n]

ob = Solution()
ob.numTrees(8)