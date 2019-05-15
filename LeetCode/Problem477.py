class Solution(object):
    def totalHammingDistance(self, nums):
        total = 0
        # check for all 32 bits and see how many numbers have them set
        n = len(nums)
        for i in range(32):
            setcount = 0
            mask = 1 << i
            for num in nums:
                if num & mask != 0:
                    setcount +=1
            total += setcount * (n - setcount)
        return total

lst = [4, 14, 2]
ob = Solution()
print(ob.totalHammingDistance(lst))