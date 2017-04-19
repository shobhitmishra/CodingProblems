#!/bin/python3

import sys
import math


n = int(input().strip())
a = []
for a_i in range(n):
    a_t = [int(a_temp) for a_temp in input().strip().split(' ')]
    a.append(a_t)

downwardSum = 0
upwardSum = 0
for i in range(n):
	downwardSum += a[i][i]
	upwardSum += a[i][n-1-i]

print(int(math.fabs(downwardSum-upwardSum)))
