from typing import List
from collections import Counter

class Solution:
    def leastInterval(self, tasks: List[str], n: int) -> int:
        freq = sorted(Counter(tasks).values())                
        maxVal = freq[-1] - 1
        idleSlots = maxVal * n
        for freq in freq[-2::-1]:
            idleSlots -= min(freq, maxVal)
        return len(tasks) + max(idleSlots, 0)

