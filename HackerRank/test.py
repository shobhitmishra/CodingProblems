def overlapping(x,y,i,j, xyval, ijval):
    xyset = set([str(val)+ str(y) for val in range(x-xyval//4, x+xyval//4 + 1)])
    xyset.update([str(x) +str(val) for val in range(y - xyval//4, y + xyval//4 + 1)])
    print(xyset)
    ijset = set([str(val) + str(j) for val in range(i-ijval//4, i+ijval//4 + 1)])
    ijset.update([str(i) + str(val) for val in range(j - ijval//4, j + ijval//4 + 1)])
    print(ijset)
    
    return bool(xyset & ijset)

print(overlapping(4,2,3,5,9,5))