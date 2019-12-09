def find_first_k_missing_positive(nums, k):
    missingNumbers = []
    i = 0
    while i < len(nums):
        j = nums[i] - 1
        if j >= 0 and j < len(nums) and nums[j] != nums[i]:
            nums[i], nums[j] = nums[j], nums[i]
        else:
            i += 1
    
    extraNumbers = set()
    for index, num in enumerate(nums):
        if len(missingNumbers) < k and num != index + 1:
            missingNumbers.append(index + 1)
            extraNumbers.add(num)
    
    seed = len(nums) + 1
    while len(missingNumbers) < k:
        if seed not in extraNumbers:
            missingNumbers.append(seed)
        seed += 1
    return missingNumbers

input = [2, 3, 4, 5, 6]
k= 4
print(find_first_k_missing_positive(input, k))