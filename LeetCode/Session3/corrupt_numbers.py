def find_corrupt_numbers(nums):
    i = 0
    result = []
    while i < len(nums):
        j = nums[i] - 1
        if nums[j] != nums[i]:
            nums[i], nums[j] = nums[j], nums[i]
        else:
            i += 1
    for index, num in enumerate(nums):
        if num != index + 1:
            result = [num, index + 1]
    return result

input = [3, 1, 2, 3, 6, 4]
print(find_corrupt_numbers(input))

