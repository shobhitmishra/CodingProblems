from collections import deque
def all_orders(numTasks, prerequisites):
    # create the graph first
    adjList = {vertex: [] for vertex in range(numTasks)}
    inDegree = {vertex: 0 for vertex in range(numTasks)}

    for requisite in prerequisites:
        fromNode, toNode = requisite[0], requisite[1]
        adjList[fromNode].append(toNode)
        inDegree[toNode] +=1

    sources = deque()
    for key, value in inDegree.items():
        if value == 0:
            sources.append(key)
    
    print_all_topological_orders(adjList, inDegree, sources, [])

def print_all_topological_orders(adjList, inDegree, sources, sortedOrder):
    if len(sortedOrder) == len(adjList):
        print(sortedOrder)
    
    for source in sources:
        sourceCopy = deque(sources)
        sourceCopy.remove(source)
        sortedOrder.append(source)

        for child in adjList[source]:
            inDegree[child] -= 1
            if inDegree[child] == 0:
                sourceCopy.append(child)
        
        print_all_topological_orders(adjList, inDegree, sourceCopy, sortedOrder)

        # back track
        sortedOrder.remove(source)
        for child in adjList[source]:
            inDegree[child] += 1

Tasks=6
Prerequisites=[2, 5], [0, 5], [0, 4], [1, 4], [3, 2], [1, 3]
all_orders(Tasks, Prerequisites)