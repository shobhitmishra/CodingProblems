class Solution:
    def countDigitOne(self, n: int) -> int:
        quotient, divider, result = n, 1, 0
        while quotient > 0:
            remainder = quotient % 10
            quotient //= 10            
            result += quotient * divider
            if remainder == 1:
                result += ((n % divider) + 1)
            elif remainder > 1:
                result += divider
            divider *= 10
        return result

ob = Solution()
print(ob.countDigitOne(13))