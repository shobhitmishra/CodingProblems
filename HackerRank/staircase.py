
import sys
printingChar = "#"
n = int(input().strip())
for i in range(n):
	printStr = " " * (n - i -1) + printingChar * (i + 1)
	print(printStr)