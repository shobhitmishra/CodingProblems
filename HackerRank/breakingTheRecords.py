#!/bin/python3

import sys

def getRecord(s):
    # Complete this function
    leastScore, mostScore = s[0], s[0]
    leastScoreCount, mostScoreCount = 0, 0
    for score in s:
    	if(score < leastScore):
    		leastScoreCount +=1
    		leastScore = score
    	if(score > mostScore):
    		mostScoreCount +=1
    		mostScore = score
    return mostScoreCount, leastScoreCount

n = int(input().strip())
s = list(map(int, input().strip().split(' ')))
result = getRecord(s)
print (" ".join(map(str, result)))
