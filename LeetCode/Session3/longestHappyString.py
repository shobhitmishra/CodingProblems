import heapq
class Solution:
    def longestDiverseString(self, a: int, b: int, c: int) -> str:
        maxHeap = []
        if a > 0:
            maxHeap.append((-a, 'a'))
        if b > 0:
            maxHeap.append((-b, 'b'))
        if c > 0:
            maxHeap.append((-c, 'c'))
        heapq.heapify(maxHeap)
        result = []
        while maxHeap:
            # insert the most frequent
            mostFreq, mostFreqChar = heapq.heappop(maxHeap)
            if len(result) >= 2 and result[-1] == result[-2] == mostFreqChar:
                if not maxHeap:
                    return ''.join(result)
                secondMostFreq, secondMostFreqChar = heapq.heappop(maxHeap)
                result.append(secondMostFreqChar)
                secondMostFreq += 1
                if secondMostFreq != 0:
                    heapq.heappush(maxHeap, (secondMostFreq, secondMostFreqChar))
                heapq.heappush(maxHeap, (mostFreq, mostFreqChar))
            else:
                result.append(mostFreqChar)
                mostFreq += 1
                if mostFreq != 0:
                    heapq.heappush(maxHeap, (mostFreq, mostFreqChar))
        return ''.join(result)

ob  = Solution()
inputs = [(2,7,10), (1,1,7), (2,2,1), (7,1,0), (6,0,0), (0,0,0)]
for a,b,c in inputs:
    print(ob.longestDiverseString(a,b,c))
