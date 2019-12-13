class Solution:
    def isHappy(self, n: int) -> bool:
        numbersAlreadySeen = set()
        number = n
        while True:
            nextNum = 0
            for digit in str(number):
                nextNum += int(digit) * int(digit)
            if nextNum in numbersAlreadySeen:
                break
            numbersAlreadySeen.add(nextNum)
            number = nextNum
        return 1 in numbersAlreadySeen

nums = [23, 12, 10, 0, 65]
ob = Solution()
for num in nums:
    print(ob.isHappy(num))