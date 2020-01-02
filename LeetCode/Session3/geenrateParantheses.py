from typing import List
class Solution:
    def generateParenthesis(self, n: int) -> List[str]:
        result = []
        self.paranthesisHelper('', 0, 0, n, result)
        return result

    def paranthesisHelper(self, str, open, close, maxParanthesis, result):
        if open + close == 2 * maxParanthesis:
            result.append(str)
        if open < maxParanthesis:
            self.paranthesisHelper(str + '(', open+1, close, maxParanthesis, result)
        if close < open:
            self.paranthesisHelper(str + ')', open, close +1, maxParanthesis, result)

ob = Solution()
for i in range(7):
    print(len(ob.generateParenthesis(i)))
    print("-----------------------")

             