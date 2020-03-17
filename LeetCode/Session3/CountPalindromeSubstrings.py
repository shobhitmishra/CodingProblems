class Solution:
    def countSubstrings(self, s: str) -> int:        
        palindromeGrid = [[False for _ in range(len(s))] for _ in range(len(s))]
        count = 0
        for i in range(len(s) - 1, -1, -1):
            for j in range(i, len(s)):
                palindromeGrid[i][j] = (s[i] == s[j]) and (j-i < 3 or palindromeGrid[i+1][j-1])
                if palindromeGrid[i][j]:
                    count += 1
        return count

strs = ["abc", "aaa", "aaab", ""]
ob = Solution()
for str in strs:
    print(ob.countSubstrings(str))