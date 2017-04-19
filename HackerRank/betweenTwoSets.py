import sys

def LcmOfTwoNumbers(a, b):
	return (a * b) // GcdOfTwoNumbers(a,b)

def GcdOfTwoNumbers(a,b):
	while(b != 0):
		a,b = b, a % b
	return a

# a is a list
def LcmOfMultipleNumbers(a):	
	result = a[0]
	for num in a:
		result = LcmOfTwoNumbers(result, num)
	return result

# b is a list
def GcdOfMultipleNumbers(b):	
	result = b[0]
	for num in b:
		result = GcdOfTwoNumbers(result, num)
	return result

n,m = input().strip().split(' ')
n,m = [int(n),int(m)]
a = [int(a_temp) for a_temp in input().strip().split(' ')]
b = [int(b_temp) for b_temp in input().strip().split(' ')]

lcmOfA = LcmOfMultipleNumbers(a)
gcdOfB = GcdOfMultipleNumbers(b)

count = 0
if(gcdOfB % lcmOfA == 0):
	multiple = 1
	while (lcmOfA * multiple <= gcdOfB):		
		if(gcdOfB % (lcmOfA * multiple) == 0):
			count +=1
		multiple +=1

print(count)