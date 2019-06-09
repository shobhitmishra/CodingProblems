def surfaceArea(A):
    totalSurfaceArea = 0
    for i in range(0, len(A)):
        for j in range(0, len(A[0])):
            totalSurfaceArea += 2
            totalSurfaceArea += getSurroundingSurfaceArea(i, j, A)    
    return totalSurfaceArea

def getSurroundingSurfaceArea(i, j, A):
    surroundingarea = 0
    currValue = A[i][j]
    # get left
    surroundingarea += currValue if j == 0 else max([0, currValue - A[i][j-1]])
    # get right
    surroundingarea += currValue if j == len(A[0]) - 1 else max([0, currValue - A[i][j+1]])
    # get up
    surroundingarea += currValue if i == 0 else max([0, currValue - A[i -1][j]])
    # get down
    surroundingarea += currValue if i == len(A) - 1 else max([0, currValue - A[i + 1][j]])
    return surroundingarea

grid = [[1,3,4], [2,2,3], [1,2,4]]
print(surfaceArea(grid))

