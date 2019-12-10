class Solution:
    def backspaceCompare(self, S: str, T: str) -> bool:
        def getNextValidIndex(source, index):
            backSpaceCount = 0
            while index >= 0:
                if source[index] == '#':
                    backSpaceCount +=1
                elif backSpaceCount > 0 :
                    backSpaceCount -= 1
                else:
                    break
                index -= 1
            return index
        sIndex = len(S) -1
        tIndex = len(T) -1
        while sIndex >= 0 or tIndex >= 0:
            sValidIndex = getNextValidIndex(S, sIndex)
            tValidIndex = getNextValidIndex(T, tIndex)
            if sValidIndex < 0 and tValidIndex < 0:
                return True
            if sValidIndex < 0 or tValidIndex < 0:
                return False
            if S[sValidIndex] != T[tValidIndex]:
                return False
            sIndex = sValidIndex -1
            tIndex = tValidIndex -1
        return True
                


S = "bbb#extm"
T = "bbbextm"
ob = Solution()
print(ob.backspaceCompare(S,T))