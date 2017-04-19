
import sys


n = int(input().strip())
arr = [int(arr_temp) for arr_temp in input().strip().split(' ')]

positive = len([pos for pos in arr if pos > 0])/len(arr)
negative = len([neg for neg in arr if neg < 0])/len(arr)
zeros = len([zero for zero in arr if zero == 0])/len(arr)
print ("{0:.6f}".format(positive))
print ("{0:.6f}".format(negative))
print ("{0:.6f}".format(zeros))