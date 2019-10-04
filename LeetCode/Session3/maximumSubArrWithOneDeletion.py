from typing import List
class Solution:
    def maximumSum(self, arr: List[int]) -> int:
        maxEndHere = [0] * len(arr)
        maxStartHere = [0] * len(arr)
        maxSum = maxEndHere[0] = arr[0]
        for i in range(1,len(arr)):
            maxEndHere[i] = max(maxEndHere[i-1] + arr[i], arr[i])
            maxSum = max(maxSum, maxEndHere[i])
        maxStartHere[-1] = arr[-1]
        for i in range(len(arr)-2, -1, -1):
            maxStartHere[i] = max(maxStartHere[i+1] + arr[i], arr[i])        
        for i in range(1,len(arr)-1):
            maxSum = max(maxSum, maxEndHere[i-1] + maxStartHere[i+1])
        return maxSum

arr = [1, -2, 0, 3]
ob = Solution()
print(ob.maximumSum(arr))
        
        
