class Solution:
    def numSteps(self, s: str) -> int:
        def isEven(num):
            return num & 1 == 0
        binaryNum = int(s, base=2)
        if binaryNum == 0:
            return 0
        steps = 0
        while binaryNum != 1:
            if isEven(binaryNum):
                binaryNum = binaryNum//2
            else:
                binaryNum += 1
            steps += 1
        return steps

inputs = ['10', '1101', '0001', '100', '11111111111111111111111000000000000000000001', '000']
ob = Solution()
for input in inputs:
    print(ob.numSteps(input))