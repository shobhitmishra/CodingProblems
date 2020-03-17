from collections import deque
from  typing import List
class Solution:
    def findMinHeightTrees(self, nodes: int, edges: List[List[int]]) -> List[int]:
        if nodes <= 0:
            return []
        
        if nodes == 1:
            return [0]

        # a. Initialize the graph
        inDegree = {i: 0 for i in range(nodes)}  # count of incoming edges
        graph = {i: [] for i in range(nodes)}  # adjacency list graph

        # b. Build the graph
        for edge in edges:
            # This is an undirected graph. Add to both and change the indegree of both
            n1, n2 = edge[0], edge[1]            
            graph[n1].append(n2)
            graph[n2].append(n1)            
            inDegree[n1] += 1
            inDegree[n2] += 1

        # c. Find all leaves i.e., all nodes with 0 in-degrees
        leaves = deque()
        for key in inDegree:
            if inDegree[key] == 1:
                leaves.append(key)

        numOfNodes = nodes
        while numOfNodes > 2:
            leavesSize = len(leaves)
            numOfNodes -= leavesSize
            for _ in range(leavesSize):
                vertex = leaves.popleft()
                # get the node's children to decrement their in-degrees
                for child in graph[vertex]:
                    inDegree[child] -= 1
                    if inDegree[child] == 1:
                        leaves.append(child)
        
        return list(leaves)

ob = Solution()
n = 4
edges = [[1, 0], [1, 2], [1, 3]]
print(ob.findMinHeightTrees(n,edges))

n = 6
edges = [[0, 3], [1, 3], [2, 3], [4, 3], [5, 4]]
print(ob.findMinHeightTrees(n,edges))

n = 5
edges = [[0, 1], [1, 2], [1, 3], [2, 4]]
print(ob.findMinHeightTrees(n,edges))