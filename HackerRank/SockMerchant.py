import sys

n = int(input().strip())
sockColors = [int(color) for color in input().strip().split(' ')]

d = dict()
for color in sockColors:
	if color not in d:
		d[color] = 0
	d[color] += 1

count = 0
for key, colorCount in d.items():
	count += colorCount // 2

print(count)