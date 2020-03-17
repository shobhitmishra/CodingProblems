def productExceptSelf(nums):
    if not nums:
        return []
    result = [1] * len(nums)
    for i in range(1, len(nums)):
        result[i] = result[i-1] * nums[i-1]
    
    mul = 1
    for i in range(len(nums) -2, -1, -1):
        mul *= nums[i+1]
        result[i] *= mul
    return result


nums = [2,4,3,5,6,2,4,3,1]
print(productExceptSelf(nums))
print([17280// num for num in nums])

