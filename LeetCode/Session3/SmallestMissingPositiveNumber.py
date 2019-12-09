def find_first_missing_positive(nums):
    i = 0
    while i < len(nums):
        j = nums[i] - 1
        if j >= 0 and j < len(nums) and nums[j] != nums[i]:
            nums[i], nums[j] = nums[j], nums[i]
        else:
            i += 1
    
    for index, num in enumerate(nums):
        if num != index + 1:
            return index + 1
    return len(nums) + 1

input = []
print(find_first_missing_positive(input))