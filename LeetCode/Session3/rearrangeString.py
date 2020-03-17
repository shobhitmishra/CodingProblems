from collections import Counter
import heapq
from collections import deque
class Solution:
    def rearrangeString(self, s: str, k: int) -> str:
        # Find the frequency of all the chars        
        freqTuple = [(-freq, ch) for ch, freq in Counter(s).items()]

        # Arrange the frequency and char in a max heap
        heapq.heapify(freqTuple)
        dq = deque()
        result = ""

        # Take the max frequency element out of the heap. Add the char to the result
        # Then add the tuple to the double ended queue
        # if the queue size has been equal to K then it means that the first item in queue
        # appeared k positions earlier. It is safe to add this char back to heap. 
        # Add the char back to heap if it has not been exhausted i.e. the count is not 0.
        while freqTuple:
            maxfreq, char = heapq.heappop(freqTuple)
            result += char
            dq.append((maxfreq+1, char))
            if len(dq) >= k:
                freq, ch = dq.popleft()
                if freq < 0:
                    heapq.heappush(freqTuple, (freq, ch))
        
        # add all the counts in dq. There shouldn't be a left over. 
        # if there is a left over then it is not possible to arrange the chars at k distance
        freqSum = sum([item[0] for item in dq])
        return "" if freqSum != 0 else result

inputs = [("aabbcc", 3), ("aaabc", 3), ("aaadbbcc", 2), ("mmpp", 2), ("Programming", 3), ("aab", 2), ("aappa", 3)]
ob = Solution()
[print(ob.rearrangeString(input[0], input[1])) for input in inputs]
