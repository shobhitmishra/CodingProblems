from typing import List
class Solution:
    def findPermutation(self, s: str) -> List[int]:        
        size = len(s)
        result = [i for i in range(1,size+2)]
        i = 0
        while i < size:            
            if s[i] == 'D':
                j = i
                while j < size and s[j] == 'D':
                    j +=1
                result = result[:i] + result[i:j +1][::-1] + result[j+1:]
                i = j
            else:
                i += 1
        return result

ob = Solution()
st = "I"
print(ob.findPermutation(st))
