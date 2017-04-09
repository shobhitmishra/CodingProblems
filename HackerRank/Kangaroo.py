import sys

x1, v1, x2, v2 = [int(val) for val in input().strip().split(' ')]

if(v1 == v2):
	if(x1 != x2):
		print("NO")
	else:
		print("YES")
else:
	time = (x2 - x1)/(v1 - v2)
	#print(time, time.is_integer())
	if(time >= 0 and time.is_integer()):
		print("YES")
	else:
		print("NO")
