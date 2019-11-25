class Solution:
    def lengthOfLongestSubstringKDistinct(self, s: str, k: int) -> int:
        if not s or not k:
            return 0
        maxLength, start = 0, 0, 
        freqCounter = dict()
        for end, ch in enumerate(s):
            if ch not in freqCounter:
                freqCounter[ch] = 0
            freqCounter[ch] += 1
            while len(freqCounter) > k:
                chToRemove = s[start]
                start += 1
                freqCounter[chToRemove] -= 1
                if freqCounter[chToRemove] == 0:
                    freqCounter.pop(chToRemove)
            maxLength = max(maxLength, end - start + 1)
        return maxLength

input = "cbbebi"
k = 0
ob = Solution()
print(ob.lengthOfLongestSubstringKDistinct(input, k))