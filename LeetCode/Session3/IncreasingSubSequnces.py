from typing import List
import itertools
class Solution:
    def findSubsequences(self, nums: List[int]) -> List[List[int]]:
        if not nums:
            return []
        k  = self.findSubsequenceHelper(nums)
        k.sort()
        result = list(k for k,_ in itertools.groupby(k))
        filteredResult = [l for l in result if len(l) > 1]
        return filteredResult
    
    def findSubsequenceHelper(self, nums: List[int]):
        if not nums:
            return []
        firstNum = nums[0]
        result = [[firstNum]]
        k = self.findSubsequenceHelper(nums[1:])
        # remove duplicates
        k.sort()
        uniqueSubResults = list(k for k,_ in itertools.groupby(k))
        for subResult in uniqueSubResults:
            if subResult:
                result.append(subResult)
                if subResult[0] >= firstNum:
                    result.append([firstNum] + subResult)
        return result

input =  [1,2,3,4,5,6,7,8,9,10,1,1,1,1,1]
ob = Solution()
print(ob.findSubsequences(input))

        
