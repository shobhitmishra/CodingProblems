class Solution:
    def nthUglyNumber(self, n: int) -> int:
        ugly_num = [1]
        idx_for2, idx_for3, idx_for5 = 0,0,0
        while len(ugly_num) < n:
            next_to_append = min(ugly_num[idx_for2]*2, ugly_num[idx_for3]*3, ugly_num[idx_for5]*5)
            ugly_num.append(next_to_append)
            if next_to_append == ugly_num[idx_for2]*2:
                idx_for2 +=1
            if next_to_append == ugly_num[idx_for3]*3:
                idx_for3 +=1
            if next_to_append == ugly_num[idx_for5]*5:
                idx_for5 +=1
        return ugly_num[-1]

ob = Solution()
print(ob.nthUglyNumber(1600))