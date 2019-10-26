from collections import Counter
from sys import maxsize
class Solution:
    def findMinStep(self, board: str, hand: str) -> int:
        handCount = Counter(hand)
        self.minSteps = maxsize
        self.minStepHelper(board, handCount, 0)
        return self.minSteps if self.minSteps < maxsize else -1
    
    def minStepHelper(self, board, handCount, steps):
        if not board:
            self.minSteps = min(self.minSteps, steps)
            return
        
        i, N = 0, len(board)
        while i < N:
            currentChar = board[i]
            j = i
            while j < N and board[j] == currentChar:
                j += 1
            sameBallCount = j-i
            if sameBallCount <=3 and handCount[currentChar] >= 3 - sameBallCount:
                handCount[currentChar] -= 3 - sameBallCount
                # call recursively on rest of the boards
                self.minStepHelper(board[:i] + board[j:], handCount, steps + 3 - sameBallCount)
                # backtrack and try other options
                handCount[currentChar] += 3 - sameBallCount
            elif sameBallCount >= 3:
                self.minStepHelper(board[:i] + board[j:], handCount, steps)
            i = j

ob = Solution()
board, hand = "RBYYBBRRB", "YRBGB"
print(ob.findMinStep(board, hand))
