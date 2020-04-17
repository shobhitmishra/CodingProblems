class Solution:
    def isHappy(self, n: int) -> bool:
        def getDigitSum(n):
            digitSum = 0
            for ch in str(n):
                digitSum += int(ch) ** 2
            return digitSum

        # define a set
        seen = set()
        seen.add(n)        
        while True:
            digitSum = getDigitSum(n)
            if digitSum == 1:
                return True 
            if digitSum in seen:
                return False                       
            seen.add(digitSum)
            n = digitSum

ob = Solution()
print(ob.isHappy(623))
for i in range(20):
    print(str(i) + " is happy: " + str(ob.isHappy(i)))

