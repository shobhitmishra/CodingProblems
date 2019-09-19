class Solution:
    def isScramble(self, s1: str, s2: str) -> bool:
        if len(s1) != len(s2):
            return False
        if s1 == s2:
            return True
        
        alphaDict = dict.fromkeys('abcdefghijklmnopqrstuvwxyz',0)
        for i in range(len(s1)):
            alphaDict[s1[i]] +=1
            alphaDict[s2[i]] -=1
        
        for val in alphaDict.values():
            if val != 0:
                return False

        for i in range(1, len(s1)):           
            if (self.isScramble(s1[:i], s2[:i]) and self.isScramble(s1[i:], s2[i:])) or (self.isScramble(s1[:i], s2[-i:]) and self.isScramble(s1[i:], s2[:-i])):
                return True
        return False

ob = Solution()
s1 = "great"
s2 = "rgeat"
print(ob.isScramble(s1, s2))
        