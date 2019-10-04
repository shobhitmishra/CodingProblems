class Solution:
    def minCut(self, s: str) -> int:
        cut = [0] * (len(s) + 1)
        cut[0] = -1
        ispal = []
        for _ in range(len(s)):
            ispal.append([False] * len(s))
        
        for i in range(len(s)):
            mincut = i
            for j in range(i+1):
                # if i to j is palindorme
                if s[i] == s[j] and (i-j <= 2 or ispal[j+1][i-1]):
                    ispal[j][i] = True
                    mincut = min(mincut, cut[j] + 1)
            cut[i+1] = mincut
        return cut[-1]

ob = Solution()
s = "aabbaa"
print(ob.minCut(s))