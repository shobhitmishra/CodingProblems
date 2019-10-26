from typing import List
class Solution:
    def minimumTotal(self, triangle: List[List[int]]) -> int:
        temp = triangle[-1]
        for row in range(len(triangle) -2, -1, -1):
            currRow = triangle[row]
            for i in range(0, len(currRow)):
                num = currRow[i]
                temp[i] = min(num + temp[i], num + temp[i+1])
            temp = temp[:-1]
        return temp[0]

triangle = [
     [2],
    [3,4],
   [6,5,7],
  [4,1,8,3],
  [2,9,5,7,6],
  [12,3,8,1,7,2]
]

ob = Solution()
print(ob.minimumTotal(triangle))
