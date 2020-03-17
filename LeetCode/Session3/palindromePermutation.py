from collections import Counter
class Solution:
    def canPermutePalindrome(self, s: str) -> bool:
        if not s:
            return True
        charCounts = Counter(s)
        oddCountChars = [ch for ch, count in charCounts.items() if count % 2 != 0]
        return len(oddCountChars) <= 1

ob = Solution()
strs = ["code", "aab","carerac"]
for str in strs:
    print(ob.canPermutePalindrome(str))