class Solution:
    def lengthOfLongestSubstring(self, s: str) -> int:
        if not s:
            return 0
        start, maxLength = 0,0        
        freqCounter = dict()
        for end, ch in enumerate(s):
            if ch not in freqCounter:
                freqCounter[ch] = 0
            freqCounter[ch] += 1
            while freqCounter[ch] > 1:
                chToRemove = s[start]
                start += 1
                freqCounter[chToRemove] -= 1
                if freqCounter[chToRemove] == 0:
                    freqCounter.pop(chToRemove)
            maxLength = max(maxLength, end - start + 1)
        return maxLength

ob = Solution()
input = "aabbcdefggklmn"
print(ob.lengthOfLongestSubstring(input))