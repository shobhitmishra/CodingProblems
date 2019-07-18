from typing import List

class Solution:
    def findRedundantConnection(self, edges: List[List[int]]) -> List[int]:
        parentDict = dict()

        # initialize all nodes
        for i in range(1,len(edges) + 1):
            parentDict[i] = i
        
        for edge in edges:
            fr,to = edge
            fromRoot = self.FindParent(fr, parentDict)
            toRoot = self.FindParent(to, parentDict)

            if fromRoot == toRoot:
                return edge
            
            parentDict[toRoot] = fromRoot
    
    def FindParent(self, node, parentDict):        
        while node != parentDict[node]:
            node = parentDict[node]
        return node

l = [[1,2], [1,3], [2,3]]
ob = Solution()
print(ob.findRedundantConnection(l))


