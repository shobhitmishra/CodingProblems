class Solution:
    def longestValidParentheses(self, s: str) -> int:
        maxLen = 0
        stack = []
        dp = [0 for _ in s]
        for i in range(len(s)):
            ch = s[i]
            if ch == '(':
                stack.append(i)
            elif stack:
                prevMatchingParan = stack.pop()
                currentLen = i - prevMatchingParan + 1
                if prevMatchingParan > 0:
                    currentLen += dp[prevMatchingParan - 1]
                dp[i] = currentLen
                maxLen = max(maxLen, currentLen)
        return maxLen

ob = Solution()
s = "(()(())(()"
print(ob.longestValidParentheses(s))