class Solution:
    def digitsCount(self, d: int, low: int, high: int) -> int:
        def countDigit(n, d):
            quotient, divider, result = n, 1, 0
            while quotient > 0:
                remainder = quotient % 10
                quotient //= 10            
                result += quotient * divider
                if remainder == d:
                    result += ((n % divider) + 1)
                elif remainder > d:
                    result += divider if d > 0 else 0
                divider *= 10
            return result
        high = countDigit(high + 1, d)
        low = countDigit(low, d)
        return high - low

ob = Solution()
print(ob.digitsCount(0,1,10))