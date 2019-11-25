def max_sub_array_of_size_k(k, arr):
      # TODO: Write your code here
    currSum, maxSum = 0 , 0
    for i in range(len(arr)):
        currSum += arr[i]    
        if i >= k -1:
            maxSum = max(maxSum, currSum)
            currSum -= arr[i-k+1]
    return maxSum
