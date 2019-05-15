class Solution(object):
    def hammingDistance(self, x, y):
        result = x ^ y
        print(result)
        # count number of set bits in result
        count = 0
        for i in range(32):
            if((result & (1 << i)) > 0):
                count += 1
        return count

ob = Solution()
print(ob.hammingDistance(1,4))
