class ListNode:
    def __init__(self, x):
        self.val = x
        self.next = None


class Solution:
    def reorderList(self, head: ListNode) -> None:
        def reverse(node):
            prev = None
            current = node
            while current:
                n = current.next
                current.next = prev
                prev = current
                current = n
            return prev
        
        if not head or not head.next:
            return
        fast, slow, prev = head, head, None
        while fast and fast.next:
            prev = slow
            slow = slow.next
            fast = fast.next.next            
        prev.next = None

        # reverse from the middle    
        newMiddle = reverse(slow)
        l1, l2, dummy = head, newMiddle, ListNode(0)
        listIndex = 0
        tail = dummy
        while l1 or l2:            
            if listIndex == 0 and l1:
                tail.next = l1
                l1 = l1.next
                if l1 == newMiddle:
                    l1 = None
            else:
                tail.next = l2
                l2 = l2.next
            
            tail = tail.next
            listIndex = (listIndex + 1) % 2

        head = dummy.next

head = ListNode(1)
head.next = ListNode(2)
head.next.next = ListNode(3)
head.next.next.next = ListNode(4)
# head.next.next.next.next = ListNode(5)
#head.next.next.next.next.next = ListNode(6)
ob = Solution()
ob.reorderList(head)
temp = head
while temp:
    print(temp.val)
    temp = temp.next