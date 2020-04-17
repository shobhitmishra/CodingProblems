class Solution:
    def moveZeroes(nums):
        j=1
        for i in range(len(nums)-1):
            if nums[i] == 0:
                while j < len(nums):
                    if nums[j] == 0:
                        j+=1
                    else:
                        #swap 
                        nums[i], nums[j] = nums[j], 0
                        break
        return nums

print(Solution.moveZeroes([0,1,2,3]))