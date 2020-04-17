class Solution:
    def myPow(self, x: float, n: int) -> float:
        if n < 0:
            return 1 / self.myPowRecur(x,-n)
        return self.myPowRecur(x,n)
        
    def myPowRecur(self,x,n):
        if n == 0:
            return 1
           
        result = self.myPowRecur(x,n//2)
        result *= result
        if n % 2 == 1:
            result *= x
        return result

#inputs = [(5,0,1), (-5,0,-1), (1,10,1), (-2,5,-32), (-2,6,64), (2,5,32), (2,-2,0.25), (-2,-2,-0.25)]
inputs = [(-1.00000,-10,1)]
ob = Solution() 
for i in inputs:
    x,n,expected = i[0], i[1], i[2]
    result = ob.myPow(x,n)
    print(result, "   ", expected)