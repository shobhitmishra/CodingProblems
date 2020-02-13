from typing import List
import math
# Definition for singly-linked list.
class ListNode:
    def __init__(self, x):
        self.val = x
        self.next = None

class Solution:
    def mergeKLists(self, lists: List[ListNode]) -> ListNode:
        if not lists:
            return None
        while len(lists) > 1:
            newList = []
            for i in range(0, len(lists), 2):
                if i == len(lists) -1:
                    newList.append(lists[i])
                    break
                list1, list2 = lists[i], lists[i + 1]
                mergedList = self.mergeTwoLists(list1, list2)
                newList.append(mergedList)
            lists = newList
        return lists[0]
    
    def mergeTwoLists(self, list1, list2):
        dummyHead = tail = ListNode(0)
        while list1 or list2:
            num1 = math.inf if not list1 else list1.val
            num2 = math.inf if not list2 else list2.val
            if num1 < num2:
                tail.next = list1
                list1 = list1.next
            else:
                tail.next = list2
                list2 = list2.next
            tail = tail.next
        return dummyHead.next

def makeLinkList(s):
    nums = [int(num) for num in s.split()]
    dummy = tail = ListNode(0)
    for num in nums:
        tail.next = ListNode(num)
        tail = tail.next
    return dummy.next

inputStr = ["1 4 5", "1 3 4", "2 6"]
input = [makeLinkList(s) for s in inputStr]
ob = Solution()
head = ob.mergeKLists(input)
print(head)


