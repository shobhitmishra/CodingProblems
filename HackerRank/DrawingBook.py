import sys
numOfPages = int(input().strip())
pageNumber = int(input().strip())

fromFront = pageNumber // 2
differnce = numOfPages - pageNumber

fromBack = (differnce + 1)//2 if numOfPages % 2 == 0 else differnce // 2

best = fromFront if fromFront < fromBack else fromBack

print(best)