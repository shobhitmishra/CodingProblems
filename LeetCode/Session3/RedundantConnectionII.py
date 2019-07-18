from typing import List
class Solution:
    unionFindParent = dict()    
    def findRedundantDirectedConnection(self, edges: List[List[int]]) -> List[int]:
        parent = dict()
        duplicateEdge = cycleMakingEdge = -1

        # first loop to find duplicateEdge
        for i in range(0, len(edges)):
            fromNode, toNode = edges[i]
            if toNode in parent:
                duplicateEdge = i
                continue
            parent[toNode] = fromNode

        # initialize unionFindParent 
        for i in range(1, len(edges) + 1):
            self.unionFindParent[i] = i

        # second loop to detect cycle
        for i in range(0, len(edges)):
            if i == duplicateEdge:
                continue
            fromNode, toNode = edges[i]
            fromParent = self.findParent(fromNode)
            toParent = self.findParent(toNode)
            if fromParent != toParent:
                self.unionNodes(fromNode, toNode)
            else:
                cycleMakingEdge = i
        
        # if there was no duplicateEdge then cycleEdge is the redundant one
        if duplicateEdge == -1:
            return edges[cycleMakingEdge]

        # if we get cycle making edge despite remove the duplicate edge then our guess was wrong
        if cycleMakingEdge != -1:
            fromNode, toNode = edges[duplicateEdge]
            fromNode = parent[toNode]
            return [fromNode, toNode]
        
        # else our guess was right
        return edges[duplicateEdge]


    def findParent(self, node):
        while node != self.unionFindParent[node]:
            node = self.unionFindParent[node]
        return node

    def unionNodes(self, node1, node2):
        self.unionFindParent[node2] = node1             
        
edges =  [[1,2],[2,3],[3,4],[4,1],[1,5]]
ob = Solution()
print(ob.findRedundantDirectedConnection(edges))

        
