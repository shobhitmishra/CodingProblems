class Solution:
    def longestDecomposition(self, text: str) -> int:
        if not text:
            return 0
        for k in range(1, 1 + len(text)//2):
            if  text[:k] == text[-k:]:
                return 2 + self.longestDecomposition(text[k:-k])
        return 1

text = "ghiabcdefhelloadamhelloabcdefghi"
ob = Solution()
print(ob.longestDecomposition(text))