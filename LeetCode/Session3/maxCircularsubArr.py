from collections import deque
class Solution():
    def maxSubarraySumCircular(self, A):
        N = len(A)

        # Compute P[j] = sum(B[:j]) for the fixed array B = A+A
        P = [0]
        for _ in range(2):
            for x in A:
                P.append(P[-1] + x)

        # Want largest P[j] - P[i] with 1 <= j-i <= N
        # For each j, want smallest P[i] with i >= j-N
        ans = A[0]
        dq = deque([0]) # i's, increasing by P[i]
        for j in range(1, len(P)):
            # If the smallest i is too small, remove it.
            if dq[0] < j-N:
                dq.popleft()

            # The optimal i is deque[0], for cand. answer P[j] - P[i].
            ans = max(ans, P[j] - P[dq[0]])

            # Remove any i1's with P[i2] <= P[i1].
            while dq and P[j] <= P[dq[-1]]:
                dq.pop()

            dq.append(j)

        return ans

nums = [2,6,-5,4,-2,-6,1,5,3,5]
ob = Solution()
print(ob.maxSubarraySumCircular(nums))