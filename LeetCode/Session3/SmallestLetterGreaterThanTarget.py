from typing import List
class Solution:
    def nextGreatestLetter(self, letters: List[str], target: str) -> str:
        start, end = 0, len(letters) - 1
        while start <= end:
            mid = (start + end) // 2
            if target == letters[mid]:
                # find the letter that is great than the current one
                while mid < len(letters) and letters[mid] == target:
                   mid += 1
                return letters[0] if mid == len(letters) else letters[mid]                    
            if target > letters[mid]:
                start = mid + 1
            else:
                end = mid - 1
        if start == len(letters):
            return letters[0]
        return letters[start]

letters = ["c", "f", "j"]
targets = ['a', 'c', 'd', 'g', 'j', 'k']
ob = Solution()
for target in targets:
    print(ob.nextGreatestLetter(letters, target))
print(ob.nextGreatestLetter(["e","e","e","e","e","e","n","n","n","n"],"n"))