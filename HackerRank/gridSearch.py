def gridSearch(G, P):
    for startRow in range(0, len(G) - len(P) + 1):
        for startCol in range(0, len(G[0]) - len(P[0]) + 1):
            if patternMatch(startRow, startCol, G, P):
                return "YES"
    return "NO"

def patternMatch(startRow, startCol, grid, pattern):
    for i in range(0,len(pattern)):
        for j in range(0, len(pattern[0])):
            if pattern[i][j] != grid[startRow + i][startCol + j]:
                return False
    return True

grid = ["7283455864",
"6731158619",
"8988242643",
"3830589324",
"2229505813",
"5633845374",
"6473530293",
"7053106601",
"0834282956",
"4607924137"]

pattern = ["7"]

print(gridSearch(grid, pattern))