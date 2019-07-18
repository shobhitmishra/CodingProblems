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
        if not root:
            result.append("#")
        else:
            result.append(str(root.val))
            self.serializeHelper(root.left, result)
            self.serializeHelper(root.right, result)

    def deserialize(self, data):
        data = data.split(",")
        root = self.deserializeHelper(data)
        return root
    
    def deserializeHelper(self, data):
        val = data.pop()
        if val == "#":
            return None
        node = TreeNode(int(val))
        node.left = self.deserializeHelper(data)
        node.right = self.deserializeHelper(data)
        return node
    
root = TreeNode(10)
root.left = TreeNode(3)
root.left.left = TreeNode(2)
root.left.right = TreeNode(8)
root.left.right.left = TreeNode(7)
root.left.right.right = TreeNode(9)

root.right = TreeNode(15)
root.right.left = TreeNode(13)
root.right.right = TreeNode(17)
root.right.right.right = TreeNode(19)

ob = Codec()
data = ob.serialize(root)
print(data)

modRoot = ob.deserialize(data)
print(modRoot)