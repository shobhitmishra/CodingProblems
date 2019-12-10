from typing import List
class Solution:
    def findMedianSortedArrays(self, nums1: List[int], nums2: List[int]) -> float:
        # nums1 should always be smaller or equal in size to nums2
        m, n = len(nums1), len(nums2)
        if m > n:
            return self.findMedianSortedArrays(nums2, nums1)
        half = (m + n + 1)//2
        start, end = 0, m
        while start <= end:
            # i runs in nums1 and j in nums2. j is derived from i
            i = (start + end) // 2
            j = half - i
            # numbers to consider are nums1[i-1], nums1[i] and nums2[j-1], nums2[j]
            # if we are on too right
            if i > 0 and nums1[i-1] > nums2[j]:
                end = i - 1
            # if we are on too left
            elif i < m and nums1[i] < nums2[j-1]:
                start = i + 1
            else:
                # we have either reached the boundary or we have found the desired partition
                maxLeft = 0
                if i <= 0:
                    maxLeft = nums2[j-1]
                elif j <= 0:
                    maxLeft = nums1[i-1]
                else:
                    maxLeft = max(nums1[i-1], nums2[j-1])
                if (m+n) %2 != 0:
                    return maxLeft
                
                minRight = 0
                if i >= m:
                    minRight = nums2[j]
                elif j >= n:
                    minRight = nums1[i]
                else:
                    minRight = min(nums1[i], nums2[j])
                
                return (maxLeft + minRight) / 2

nums1 = [100001]
nums2 = [100000]
ob = Solution()
print(ob.findMedianSortedArrays(nums1, nums2))