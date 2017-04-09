import sys

n, k = [int(item) for item in input().strip().split(' ')]
costs = [int(cost) for cost in input().strip().split(' ')]
bCharged = int(input().strip())

bActual = (sum(costs) - costs[k])//2
if(bActual == bCharged):
	print("Bon Appetit")
else:
	print(bCharged - bActual)
