def bomberMan(n, grid):
    configAtOneSecond = [list(word) for word in grid]
    configAtEvenSeconds = [list('O' * len(grid[0])) for word in grid]
    configAtThreeSeconds = GetConfigAtThreeSeconds(grid)
    if(n % 4 == 1):
        return ConvertListOfListToListOfString(configAtOneSecond)
    if(n % 2 == 0):
        return ConvertListOfListToListOfString(configAtEvenSeconds)
    if(n % 3 == 0):
        return ConvertListOfListToListOfString(configAtThreeSeconds)

def ConvertListOfListToListOfString(grid):
    result = [''.join(l) for l in grid]
    return result

def GetConfigAtThreeSeconds(grid):
    result = [list('O' * len(grid[0])) for word in grid]
    for i in range(0,len(grid)):
        for j in range(0,len(grid[i])):
           #if there is a bomb at i,j, detonate
           if grid[i][j] == 'O':
                result[i][j] = '.'
                # detonate surrounding bombs as well
                if i > 0:
                   result[i-1][j] = '.'
                if i < len(grid) - 1:
                    result[i+1][j] = '.'
                if j > 0:
                    result[i][j-1] = '.'
                if j < len(grid[0]) - 1:
                    result[i][j+1] = '.'
    return result

grid = ['.......',
'...O...',
'....O..',
'.......',
'OO.....',
'OO.....']
print(bomberMan(3, grid))