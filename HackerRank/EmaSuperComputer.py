import itertools

def twoPluses(grid):
    # find the largest plus at ever position and store it
    results = [[0 for j in grid[0]] for i in grid]
    for i in range(len(grid)):
        for j in range(len(grid[0])): 
            if grid[i][j] == 'G':           
                results[i][j] = GetLargestPlusAtThisPosition(i,j,grid)
    
    # take two grid points and multiply them if they are not overlapping
    maxProduct = 0
    for i in range(len(results)):
        for j in range(len(results[0])):
            if results[i][j] != 0:
                maxProduct = max([maxProduct, GetMaxProduct(i,j,results)])
    return maxProduct

def GetMaxProduct(x,y,result):
    maxProduct = 0
    value = result[x][y]
    for i in range(x, len(result)):
        for j in range(y, len(result[0])):            
            if result[i][j] != 0:
                # if they are non overlapping 
                if not overlapping(x,y,i,j,result):
                    maxProduct = max([maxProduct, value * result[i][j]])
    return maxProduct

def overlapping(x,y,i,j,result):
    xyval = result[x][y]
    ijval = result[i][j]
    xyset = set([str(val)+ str(y) for val in range(x-xyval//4, x+xyval//4 + 1)])
    xyset.update([str(x) +str(val) for val in range(y - xyval//4, y + xyval//4 + 1)])
    #print(xyset)
    ijset = set([str(val) + str(j) for val in range(i-ijval//4, i+ijval//4 + 1)])
    ijset.update([str(i) + str(val) for val in range(j - ijval//4, j + ijval//4 + 1)])
    #print(ijset)
    
    return bool(xyset & ijset)

def GetLargestPlusAtThisPosition(x,y,grid):
    up = down = left = right = 0
    for i in range(x-1,-1,-1):
        if grid[i][y] == 'B':
            break
        up +=1
    for i in range(x+1, len(grid)):
        if grid[i][y] == 'B':
            break
        down +=1
    for j in range(y-1,-1,-1):
        if grid[x][j] == 'B':
            break
        left +=1
    for j in range(y+1,len(grid[0])):
        if grid[x][j] == 'B':
            break
        right +=1
    result = min([up, down, left, right]) * 4 + 1    
    return result

grid = ['GGGGGGGGGGGG',
'GBGGBBBBBBBG',
'GBGGBBBBBBBG',
'GGGGGGGGGGGG',
'GGGGGGGGGGGG',
'GGGGGGGGGGGG',
'GGGGGGGGGGGG',
'GBGGBBBBBBBG',
'GBGGBBBBBBBG',
'GBGGBBBBBBBG',
'GGGGGGGGGGGG',
'GBGGBBBBBBBG']
print(twoPluses(grid))
