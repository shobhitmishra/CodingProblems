from collections import defaultdict
class Solution:
    def kSimilarity(self, str1: str, str2: str) -> int:
        result = defaultdict(int)
        count = 0
        for ch1,ch2 in zip(str1, str2):
            if ch1 != ch2:
                if result[(ch2, ch1)] > 0:
                    result[(ch2,ch1)] -= 1
                    count += 1
                else:
                    result[(ch1,ch2)] +=1
        val = sum(result.values())
        if val > 0:
            count += val -1                
        return count

ob = Solution()
str1, str2 = "aabbccddee", "dcacbedbae"
print(ob.kSimilarity(str1, str2))