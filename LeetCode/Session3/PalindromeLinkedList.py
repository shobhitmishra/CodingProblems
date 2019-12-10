class ListNode:
    def __init__(self, x):
        self.val = x
        self.next = None

class Solution:
    def isPalindrome(self, head: ListNode) -> bool:
        def reverse(node):
            prev = None
            current = node
            while current:
                n = current.next
                current.next = prev
                prev = current
                current = n
            return prev

        if not head:
            return True
        fast, slow = head, head
        while fast and fast.next:
            slow = slow.next
            fast = fast.next.next            

        # reverse from the middle    
        newMiddle = reverse(slow)
        # compare the new list with the old list
        first, second = head, newMiddle
        while second:
            if first.val != second.val:
                return False
            first = first.next
            second = second.next
        return True

head = ListNode(2)
head.next = ListNode(4)
head.next.next = ListNode(6)
head.next.next.next = ListNode(4)
head.next.next.next.next = ListNode(2)
#head.next.next.next.next.next = ListNode(2)
ob = Solution()
print(ob.isPalindrome(head))