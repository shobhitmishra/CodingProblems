import sys


a,b,c,d,e = input().strip().split(' ')
l = [int(a),int(b),int(c),int(d),int(e)]
overallSum = sum(l)
minVal = min(l)
maxVal = max(l)
print(overallSum - maxVal, overallSum - minVal)
