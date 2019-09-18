from typing import List
import collections
class Solution:  
    def sumOfDistancesInTree(self, N, edges):
        adjList = collections.defaultdict(set)
        result = [0] * N
        subTreeNodeCount = [1] * N
        for fromNode, toNode in edges:
            adjList[fromNode].add(toNode)
            adjList[toNode].add(fromNode)

        def countNodes(root, pre):
            for neighbor in adjList[root]:
                if neighbor != pre:
                    countNodes(neighbor, root)
                    subTreeNodeCount[root] += subTreeNodeCount[neighbor]
                    result[root] += result[neighbor] + subTreeNodeCount[neighbor]

        def calucateDistance(root, pre):
            for neighbor in adjList[root]:
                if neighbor != pre:
                    result[neighbor] = result[root] - subTreeNodeCount[neighbor] + N - subTreeNodeCount[neighbor]
                    calucateDistance(neighbor, root)
        
        countNodes(0, -1)
        calucateDistance(0, -1)
        return result
        
input = []
ob = Solution()
print(ob.sumOfDistancesInTree(1, []))
