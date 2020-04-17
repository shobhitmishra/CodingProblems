def generateSubsetsRecursive(nums):    
    def generateSubsetsHelper(nums, currLevel, currList, result):
        if currLevel == len(nums):
            result.append(list(currList))
        else:
            currList.append(nums[currLevel])
            generateSubsetsHelper(nums, currLevel + 1, currList, result)
            currList.pop()
            generateSubsetsHelper(nums, currLevel + 1, currList, result)
    result, currList, currLevel = [], [], 0
    generateSubsetsHelper(nums, currLevel, currList, result)
    return result

def generatateSubsetsIterative(nums):
    ans = [[]]
    for num in nums:
        newAns = []
        for l in ans:
            newAns.append(l +[num])
        ans += newAns
    return ans

def generatateUniqueSubsetsIterative(nums):
    ans, prevAns = [[]], None
    for index, num in enumerate(nums):
        listToIterate = ans
        if index > 0 and nums[index] == nums[index-1]:
            listToIterate = prevAns
        newAns = []
        for l in listToIterate:
            newAns.append(l +[num])
        prevAns = newAns
        ans += newAns
    return ans

def generatePermutationsRecursive(nums):
    def generatePermutationsHelper(nums, currentList, isIncluded, results):
        if len(currentList) == len(nums):
            results.append(list(currentList))
        else:
            for i in range(len(nums)):
                if isIncluded[i]:
                    continue
                currentList.append(nums[i])
                isIncluded[i] = True                
                generatePermutationsHelper(nums, currentList, isIncluded, results)
                currentList.pop()
                isIncluded[i] = False

    result, currList, isIncluded = [], [], [False] * len(nums)
    generatePermutationsHelper(nums, currList, isIncluded, result)
    return result

def generatePermutationsIterative(nums):
    ans = [[]]
    for num in nums:
        newAns = []
        for l in ans:
            for i in range(len(l) + 1):                    
                newAns.append(l[:i] + [num] + l[i:])
        ans = newAns
    return ans

def generateUniquePermutation(nums):
    ans = [[]]
    for num in nums:
        newAns = []
        for l in ans:
            for i in range(len(l) + 1):                    
                newAns.append(l[:i] + [num] + l[i:])
                if i < len(l) and num == l[i]:
                    break
        ans = newAns
    return ans


nums = [1,2,2]
#print(generateSubsetsRecursive(nums))
# print(generatateSubsetsIterative(nums))
# print(generatateUniqueSubsetsIterative(nums))
# print(generatePermutationsRecursive(nums))
print(generatePermutationsIterative(nums))
print(generateUniquePermutation(nums))