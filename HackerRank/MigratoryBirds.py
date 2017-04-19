#!/bin/python3

import sys


n = int(input().strip())
types = list(map(int, input().strip().split(' ')))
# your code goes here
typleList = [0] * 5

for birdType in types:
	typleList[birdType - 1] += 1

print(typleList.index(max(typleList)) + 1)
