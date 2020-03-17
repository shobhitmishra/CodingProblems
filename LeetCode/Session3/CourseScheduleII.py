from typing import List
from collections import defaultdict
class Solution:
    def findOrder(self, numCourses: int, prerequisites: List[List[int]]) -> bool:
        edges = defaultdict(set)
        for requisite in prerequisites:
            fromNode, toNode = requisite[1], requisite[0]
            edges[fromNode].add(toNode)

        visited, explored, order = set(), set(), []
        for node in range(numCourses):
            if node not in explored:
                result = self.DoDFS(node, edges, visited, explored, order)
                if not result:
                    return []
        
        return order[::-1]
    
    def DoDFS(self, node, edges, visited, explored, order):
        if node in explored:
            return True
        
        if node in visited:
            return False

        visited.add(node)
        for neighbor in edges[node]:
            result = self.DoDFS(neighbor, edges, visited, explored, order)
            if not result:
                return False
        visited.remove(node)
        explored.add(node)
        order.append(node)
        return True

numCourses, preRequisite = 2, [[1,0], [0,1]]
ob = Solution()
print(ob.findOrder(numCourses, preRequisite))