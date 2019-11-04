from typing import List
import collections
class Solution:
    def findLonelyPixel(self, picture: List[List[str]]) -> int:
        rowDict = collections.defaultdict(list)
        for rowNum, row in enumerate(picture):
            for colNum, pixel in enumerate(row):
                if pixel == 'B':
                    rowDict[rowNum].append(colNum)
        
        count = 0
        allCoumnValues = []
        for columnValues in rowDict.values():
            allCoumnValues += columnValues
        allColumnsPositions = collections.Counter(allCoumnValues)
        for columns in rowDict.values():
            if len(columns) > 1:
                continue
            if allColumnsPositions[columns[0]] == 1:
                count +=1
        return count

input = [[]]

ob = Solution()
print(ob.findLonelyPixel(input))