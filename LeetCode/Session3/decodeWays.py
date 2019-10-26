class Solution:
    def numDecodings(self, s: str) -> int:
        numDecoding = [0] * (len(s) + 1)
        numDecoding[0] = 1
        for i in range(len(s)):
            oneWord = int(s[i])
            if oneWord > 0 and oneWord < 10:
                numDecoding[i+1] = numDecoding[i]
            if i > 0:
                twoWord = int(s[i-1:i+1])
                if twoWord >= 10 and twoWord <= 26:
                    numDecoding[i+1] += numDecoding[i-1]
        return numDecoding[-1]

ob = Solution()
input = "226"
print(ob.numDecodings(input))
