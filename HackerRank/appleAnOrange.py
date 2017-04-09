import sys
s,t = [int(val) for val in input().strip().split(' ')]
a,b = [int(val) for val in input().strip().split(' ')]
m,n = [int(val) for val in input().strip().split(' ')]
apple = [int(apple_temp) for apple_temp in input().strip().split(' ')]
orange = [int(orange_temp) for orange_temp in input().strip().split(' ')]

appleCount, orangeCount = 0, 0
for appleDist in apple:
	if(a + appleDist >= s and a + appleDist <=t):
		appleCount +=1
for orangeDist in orange:
	if(b + orangeDist >= s and b + orangeDist <= t):
		orangeCount +=1

print(appleCount)
print(orangeCount)