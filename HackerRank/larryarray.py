def larrysArray(A):
    inversion = 0
    for i in range(len(A)):
        for j in range(i+1, len(A)):
            inversion += 1 if A[i] > A[j] else 0
    return 'YES' if inversion % 2 == 0 else 'NO'

A = [1, 6, 5, 2, 4, 3]
print(larrysArray(A))