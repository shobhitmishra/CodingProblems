import sys

n,k = input().strip().split(' ')
n,k = [int(n),int(k)]
a = list(map(int, input().strip().split(' ')))
# write your code here
count = 0;
for i in range(0, len(a)):
	for j in range(i + 1, len(a)):
		if((a[i] + a[j]) % k == 0):
			count +=1
print(count)