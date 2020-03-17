class Solution:
    def countAndSay(self, n: int) -> str:
        def getNextCountAndSay(s):
            result = ''
            count = 1
            for i in range(1,len(s) + 1):
                if i == len(s):
                    result += str(count) + s[i-1]
                elif s[i] == s[i-1]:
                    count +=1 
                else:
                    result += str(count) + s[i-1]
                    count = 1
            return result
        if n == 1:
            return "1"
        if n == 2:
            return '11'
        s = '11'
        for _ in range(3,n+1):
            s = getNextCountAndSay(s)
        return s

ob = Solution()
for i in range(1,20):
    print(ob.countAndSay(i))

