# The questions is askin us to find the articulation points
# We'll use modified DFS to detect ariculation points
time  = 0
def criticalRouters(numRouters, numLinks, links):
    # WRITE YOUR CODE HERE
    adjList = dict()
    for i in range(1,numRouters + 1):
        adjList[i] = list()
    
    for link in links:
        node1, node2 = link[0], link[1]
        adjList[node1].append(node2)
        adjList[node2].append(node1)
    
    ap = DFSTraversal(adjList)
    result = []
    for index, val in enumerate(ap):
        if val == True:
            result.append(index)
    return result
    

def DFSTraversal(adjList):
    # maintain visited nodes, parent of visited nodes
    numNodes = len(adjList) + 1
    visited = [False] * numNodes
    parent = [-1] * numNodes

    # discovered stores the time of discovery
    discovered = [float('inf')] * numNodes
    # stores the ancestor with lowest doscovered time
    ancestorWithLowest = [float('inf')] * numNodes

    articulationPoint = [False] * numNodes

    # start the traversal
    for node in adjList.keys():
        if visited[node] == False:
            DFSTravesalRecursive(adjList, node, visited, articulationPoint, parent, ancestorWithLowest, discovered)
    
    return articulationPoint


def DFSTravesalRecursive(adjList, node, visited, articulationPoint, parent, ancestorWithLowest, discovered):
    children = 0
    visited[node] = True

    # init discover time and andestor low
    global time
    discovered[node] = time
    ancestorWithLowest[node] = time
    time += 1

    for neighbor in adjList[node]:
        if visited[neighbor] == False:
            parent[neighbor] = node
            children += 1
            DFSTravesalRecursive(adjList, neighbor, visited, articulationPoint, parent, ancestorWithLowest, discovered)

            ancestorWithLowest[node] = min(ancestorWithLowest[node], ancestorWithLowest[neighbor])

            # if node is root and has two or more children, it is AP
            if parent[node] == -1 and children > 1:
                articulationPoint[node] = True
            
            # if node is not root and low value of children is more than discoery of node then it is AP
            if parent[node] != -1 and ancestorWithLowest[neighbor] > discovered[node]:
                articulationPoint[node] = True

        elif neighbor != parent[node]:
            ancestorWithLowest[node] = min(ancestorWithLowest[node], discovered[neighbor])

print(criticalRouters(7,7,[[1,2],[1,3],[2,4],[3,4],[3,6],[6,7],[4,5]]))