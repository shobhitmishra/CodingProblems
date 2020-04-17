class Solution:
    def entityParser(self, text: str) -> str:
        symbolDict = {"&quot;" : '"', "&apos;": "'", "&amp;": "&", "&gt;": ">", "&lt;": "<", "&frasl;": "/"}
        for key,val in symbolDict.items():
            text = text.replace(key, val)
        return text

inputs = ["&amp; is an HTML entity but &ambassador; is not.", "and I quote: &quot;...&quot;", "Stay home! Practice on Leetcode :)", "x &gt; y &amp;&amp; x &lt; y is always false", "leetcode.com&frasl;problemset&frasl;all"]
ob = Solution()
for text in inputs:
    print(text)
    print(ob.entityParser(text))