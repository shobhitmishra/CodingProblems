from typing import List
class Solution:
    def intervalIntersection(self, A: List[List[int]], B: List[List[int]]) -> List[List[int]]:
        def isOverlap(start1, end1, start2, end2):
            if end1 < start2 or end2 < start1:
                return False
            return True
        if not A or not B:
            return []
        result = []
        ptr1, ptr2 = 0, 0
        while ptr1 < len(A) and ptr2 < len(B):
            start1, end1 = A[ptr1][0], A[ptr1][1]
            start2, end2 = B[ptr2][0], B[ptr2][1]

            if isOverlap(start1, end1, start2, end2):
                result.append([max(start1, start2), min(end1, end2)])            
            if end1 < end2:
                ptr1 +=1
            else:
                ptr2 +=1

        return result

A = [[0,2],[5,10],[13,23],[24,25]]
B = [[1,5],[8,12],[15,24],[25,26]]
ob = Solution()
print(ob.intervalIntersection([], B))