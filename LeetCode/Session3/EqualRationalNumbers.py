from fractions import Fraction
class Solution:
    def isRationalEqual(self, S: str, T: str) -> bool:
        def getFraction(s: str):
            if '(' not in s:
                return Fraction(s)
            
            non_repeat, repeat = s.split('(')
            # remove the closing bracket
            repeat = repeat[:-1]
            _, non_repeat_decimal = non_repeat.split('.')
            repeat_fraction = Fraction(int(repeat), (10 ** len(repeat) -1) * (10 ** len(non_repeat_decimal)))
            return Fraction(non_repeat) + repeat_fraction
        
        sFraction = getFraction(S)
        tFraction = getFraction(T)
        return sFraction == tFraction

S = "0.(52)"
T = "0.5(25)"
ob = Solution()
print(ob.isRationalEqual(S,T))

