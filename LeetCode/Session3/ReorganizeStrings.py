class Solution:
    def reorganizeString(self, string: str) -> str:
        sortedStr = sorted(sorted(string), key= string.count, reverse=True)

        # divide the string in two parts and zip them together
        halfSize = (len(string) + 1)//2
        firstHalf = sortedStr[0:halfSize]
        secondHalf = sortedStr[halfSize:]
        if len(secondHalf) < len(firstHalf):
            secondHalf += " "
        result = ["".join(x).strip() for x in zip(firstHalf, secondHalf)]

        # if the first tuple had the same characters then one of the chars occured more than half times.
        if result[0][:] == result[0][::-1]:
            return ""

        return "".join(result)

ob = Solution()
input = "aab"
print(ob.reorganizeString(input))

