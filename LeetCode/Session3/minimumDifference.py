from sys import maxsize
def search_min_diff_element(arr, key):
    start, end, minDiffNum = 0, len(arr) -1, maxsize
    while start <= end:
        mid = (start + end) //2
        num = arr[mid]
        if num == key:
            return key
        elif num < key:
            start = mid + 1
        else:
            end = mid - 1
        if abs(key - num) < abs(key - minDiffNum):
            minDiffNum = num
    return minDiffNum


def main():
    print(search_min_diff_element([4, 6, 10], 7))
    print(search_min_diff_element([4, 6, 10], 4))
    print(search_min_diff_element([1, 3, 8, 10, 15], 12))
    print(search_min_diff_element([4, 6, 10], 17))


main()