from typing import List
class Solution:
    def twoSum(self, numbers: List[int], target: int) -> List[int]:
        start, end = 0, len(numbers) -1
        while start < end:
            sumOfNums = numbers[start] + numbers[end]
            if sumOfNums == target:
                return [start +1, end+1]
            elif sumOfNums < target:
                start += 1
            else:
                end -=1
        return [-1,-1]

numbers = [2,7,11,15]
target = 9
ob = Solution()
print(ob.twoSum(numbers, target))