from collections import deque
from typing import List
from collections import defaultdict
class Solution:
    def sequenceReconstruction(self, org: List[int], seqs: List[List[int]]) -> bool:
        adjList = defaultdict(list)
        inDegree = defaultdict(int)        
        for seq in seqs:            
            for i in range(len(seq) -1):
                fromNode, toNode = seq[i], seq[i+1]
                if i == 0:
                    inDegree[fromNode] += 0
                adjList[fromNode].append(toNode)
                inDegree[toNode] +=1
        
        return self.topologicalSort(adjList, inDegree, org)

    def topologicalSort(self, adjList, inDegree, org):
        sources= deque()
        for key, val in inDegree.items():
            if val == 0:
                sources.append(key)
        sortedOrder = []

        while sources:
            if len(sources) > 1:
                return False

            source = sources.popleft()
            sortedOrder.append(source)
            for child in adjList[source]:
                inDegree[child] -= 1
                if inDegree[child] == 0:
                    sources.append(child)
        
        return sortedOrder == org

org= [1]
seqs= [[1],[1],[1]]
ob = Solution()
print(ob.sequenceReconstruction(org, seqs))