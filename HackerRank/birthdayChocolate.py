import sys

def getWays(squares, d, m):
    # Complete this function
    cumSum = [0]
    for val in squares:
    	cumSum.append(cumSum[-1] + val)
    #print(cumSum)
    count = 0
    for i in range(1, len(cumSum) - m + 1):
    	sumVal = cumSum[i + m - 1] - cumSum[i -1]
    	#print(sumVal)
    	if(sumVal == d):
    		count +=1
    return count

n = int(input().strip())
s = list(map(int, input().strip().split(' ')))
d,m = input().strip().split(' ')
d,m = [int(d),int(m)]
result = getWays(s, d, m)
print(result)
