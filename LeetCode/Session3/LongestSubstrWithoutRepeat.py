class Solution:
    def lengthOfLongestSubstring(self, s: str) -> int:           
        left = maxLen = 0
        charMap = dict()
        for right in range(len(s)):
            ch = s[right]
            if ch in charMap:                
                left = max(left, charMap[ch] + 1)
            maxLen = max(maxLen, right - left + 1)
            charMap[ch] = right
        
        return maxLen

ob = Solution()
s = "abba"
print(ob.lengthOfLongestSubstring(s))

