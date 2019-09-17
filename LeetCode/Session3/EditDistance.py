class Solution:
    def minDistance(self, word1: str, word2: str) -> int:
        result = [[0 for _ in range(len(word2)+1)] for _ in range(len(word1) + 1)]

        # update top row
        for j in range(1,len(word2)+1):
            result[0][j] = 1+ result[0][j-1]

        # update first column
        for i in range(1,len(word1) +1):
            result[i][0] = 1 + result[i-1][0]
        
        for i in range(1,len(word1) +1):
             for j in range(1,len(word2)+1):
                if word1[i-1] == word2[j-1]:
                    result[i][j] = result[i-1][j-1]
                else:
                    result[i][j] = 1 + min(result[i-1][j-1], result[i][j-1], result[i-1][j])

        return result[len(word1)][len(word2)] 

word1 = "intention"
word2 = "execution"
ob = Solution()
print(ob.minDistance(word2, word1))