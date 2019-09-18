class TreeNode:
    def __init__(self, x):
        self.val = x
        self.left = None
        self.right = None

class Solution:
    currPos = -1
    def str2tree(self, s: str) -> TreeNode:
        self.currPos +=1
        if self.currPos >= len(s):
            return None
        
        numStr = ""
        while self.currPos < len(s):
            ch = s[self.currPos]
            if ch == '(' or ch == ')':
                break
            numStr += ch
            self.currPos += 1
        
        node = TreeNode(int(numStr))

        if self.currPos < len(s) and s[self.currPos] == '(':
            node.left = self.str2tree(s)
            if self.currPos < len(s) and s[self.currPos] == '(':
                node.right = self.str2tree(s)
        
        self.currPos +=1
        return node
        

s = "4"
ob = Solution()
node = ob.str2tree(s)
print(node)
