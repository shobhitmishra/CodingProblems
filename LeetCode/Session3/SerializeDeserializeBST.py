import sys
class TreeNode:
    def __init__(self, x):
        self.val = x
        self.left = None
        self.right = None

class Codec:
    def serialize(self, root):
        result = []
        self.serializeHelper(root, result)
        result.reverse()
        return ",".join(result)

    def serializeHelper(self, root, result):
        if root:
            result.append(str(root.val))
            self.serializeHelper(root.left, result)
            self.serializeHelper(root.right, result)

    def deserialize(self, data):   
        if not data:
            return None     
        dataq = [int(num) for num in data.split(",")]
        return self.deserializeHelper(dataq, -sys.maxsize, sys.maxsize)

    def deserializeHelper(self, data, leftLimit, rightLimit):
        if not data:
            return None
        
        if data[-1] < leftLimit or data[-1] > rightLimit:
            return None
                
        node = TreeNode(data.pop())
        node.left = self.deserializeHelper(data, leftLimit, node.val)
        node.right = self.deserializeHelper(data, node.val, rightLimit)
        return node

root = TreeNode(10)
root.left = TreeNode(8)
root.left.left = TreeNode(7)
root.left.right = TreeNode(9)

root.right = TreeNode(12)
root.right.left = TreeNode(11)
root.right.right = TreeNode(15)
root.right.right.right = TreeNode(17)
root.right.right.right.right = TreeNode(18)

root.right.right.left = TreeNode(13)
root.right.right.left.right = TreeNode(14)

ob = Codec()
data = ob.serialize(None)
print(data)

node = ob.deserialize(data)
print(node)

    