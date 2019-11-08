from collections import defaultdict
class Solution:
    def characterReplacement(self, s: str, k: int) -> int:
        if not s:
            return 0
        maxLength, start, maxRepeatingCount = 0, 0, 0
        freqCounter = defaultdict(int)
        for end, ch in enumerate(s):
            freqCounter[ch] += 1
            maxRepeatingCount = max(maxRepeatingCount, freqCounter[ch])
            if end - start + 1 - maxRepeatingCount > k:
                freqCounter[s[start]] -= 1
                start += 1
            maxLength = max(maxLength, end - start + 1)
        return maxLength

input = "abccde"
k=1
ob = Solution()
print(ob.characterReplacement(input, k))