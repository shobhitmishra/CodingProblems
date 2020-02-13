from typing import List
import math
import heapq
# Definition for singly-linked list.
class ListNode:
    def __init__(self, x):
        self.val = x
        self.next = None

class Solution:
    def mergeKLists(self, lists: List[ListNode]) -> ListNode:
        heap = [(list.val, index, list) for index, list in enumerate(lists) if list]
        heapq.heapify(heap)
        dummyHead = tail = ListNode(0)

        while heap:
            _, index, list = heapq.heappop(heap)
            tail.next = list
            tail = tail.next
            list = list.next
            if list:
                heapq.heappush(heap, (list.val, index, list))
        return dummyHead.next

def makeLinkList(s):
    nums = [int(num) for num in s.split("->")]
    dummy = tail = ListNode(0)
    for num in nums:
        tail.next = ListNode(num)
        tail = tail.next
    return dummy.next

inputStr = ["1->4->5", "1->3->4", "2->6"]
input = [makeLinkList(s) for s in inputStr]
ob = Solution()
head = ob.mergeKLists(input)
print(head)