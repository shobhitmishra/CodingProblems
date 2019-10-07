from typing import List
class Solution:
    def kConcatenationMaxSum(self, arr: List[int], k: int) -> int:
        def kadandeAlgo(arr):
            currSum = maxSum = 0
            for num in arr:
                currSum = max(0, currSum + num)
                maxSum = max(maxSum, currSum)
            return maxSum
        mod = 10 ** 9 + 7
        kadaneSum = kadandeAlgo(arr*2) if k > 1 else kadandeAlgo(arr)
        return (max(0, (k-2) * sum(arr)) + kadaneSum) % mod

input = [-5,4,-4,-3,5,-3]
ob = Solution()
print(ob.kConcatenationMaxSum(input, 3))