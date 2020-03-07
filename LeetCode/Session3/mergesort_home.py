import random
def mergeSort(arr):
    if len(arr) <= 1:
        return arr
    half = len(arr) // 2
    sortedLeft = mergeSort(arr[:half])
    sortedRight = mergeSort(arr[half:])
    return mergeSortedArrays(sortedLeft, sortedRight)

def mergeSortedArrays(left, right):
    leftIndex, rightIndex = 0 , 0
    result = []
    while leftIndex < len(left) and rightIndex < len(right):
        if left[leftIndex] < right[rightIndex]:
            result.append(left[leftIndex])
            leftIndex += 1
        else:
            result.append(right[rightIndex])
            rightIndex += 1
    if leftIndex < len(left):
        result.extend(left[leftIndex:])
    elif rightIndex < len(right):
        result.extend(right[rightIndex:])
    return result

def generateRandomNumbers(count = 10, start = -10, end = 10):
    result = []
    for _ in range(count):
        result.append(random.randint(start, end))
    return result

for i in range(10):
    nums = generateRandomNumbers()
    mergeSortedNums = mergeSort(nums)
    sortedNums = sorted(nums)    
    print("Sorting works") if sortedNums == mergeSortedNums else print("Failed")

nums = [1,2,3,4]
print(mergeSort(nums))

nums = []
print(mergeSort(nums))

nums = [4,3,2,1]
print(mergeSort(nums))