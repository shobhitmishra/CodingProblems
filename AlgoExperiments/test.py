nums = [1,2,3]
for i in range(len(nums)+1):
    print(nums[:i] + [4] + nums[i:])
    