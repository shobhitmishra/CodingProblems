from typing import List
from collections import deque
class Solution:
    def alienOrder(self, words: List[str]) -> str:
        charSet = set()
        for word in words:
            for ch in word:
                charSet.add(ch)
        adjList = {ch: set() for ch in charSet}
        inDegree = {ch: 0 for ch in charSet}

        for i in range(len(words) -1):
            w1, w2 = words[i], words[i+1]
            for j in range(min(len(w1), len(w2))):                
                parent, child = w1[j], w2[j]      
                if parent != child:          
                    if child not in adjList[parent]:
                        adjList[parent].add(child)
                        inDegree[child] += 1
                    break
        
        sources = deque()
        for key, val in inDegree.items():
            if val == 0:
                sources.append(key)
        
        return self.topologicalOrder(adjList, inDegree, sources)
    
    def topologicalOrder(self, adjList, inDegree, sources):
        sortedOrder = []
        while sources:
            source = sources.popleft()
            sortedOrder.append(source)
            for child in adjList[source]:
                inDegree[child] -= 1
                if inDegree[child] == 0:
                    sources.append(child)
        
        if len(sortedOrder) != len(adjList):
            return ""
        return "".join(sortedOrder)

words = ["ba", "bc", "ac", "cab"]
ob = Solution()
print(ob.alienOrder(words))