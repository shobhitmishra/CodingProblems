from typing import List
from collections import defaultdict
class Solution:
    def canFinish(self, numCourses: int, prerequisites: List[List[int]]) -> bool:
        edges = defaultdict(set)
        for requisite in prerequisites:
            fromNode, toNode = requisite[1], requisite[0]
            edges[fromNode].add(toNode)

        visited, explored = set(), set()
        for node in range(numCourses):
            if node not in explored:
                result = self.DoDFS(node, edges, visited, explored)
                if not result:
                    return False
        
        return True
    
    def DoDFS(self, node, edges, visited, explored):
        if node in explored:
            return True
        
        if node in visited:
            return False

        visited.add(node)
        for neighbor in edges[node]:
            result = self.DoDFS(neighbor, edges, visited, explored)
            if not result:
                return False
        visited.remove(node)
        explored.add(node)
        return True

numCourses, preRequisite = 4, [[3, 2], [3, 0], [2, 0], [2, 1], []]
ob = Solution()
print(ob.canFinish(numCourses, preRequisite))