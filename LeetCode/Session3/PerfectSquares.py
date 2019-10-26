class Solution:
    def numSquares(self, n: int) -> int:
        if n < 2:
           return n
        squares = [i*i for i in range(int(n ** 0.5) + 1)]
        target = [n]
        distance = 0
        while target:
            distance +=1
            temp = []
            for item in target:
                for square in squares:
                    if item == square:
                        return distance
                    if item < square:
                        break
                    temp.append(item - square)
            target = temp
        return distance

ob = Solution()
print(ob.numSquares(8405))
